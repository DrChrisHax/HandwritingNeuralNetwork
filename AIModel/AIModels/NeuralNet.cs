using HandwritingNeuralNetwork.AIModel.AIModels;
using HandwritingNeuralNetwork.Models;
using HandwritingNeuralNetwork.Shared;
using System;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace HandwritingNeuralNetwork.AIModel
{
    /*
     * DEPRECATED
     */
    public class NeuralNet : AIModelBase
    {
        private int _inputSize;
        private int _hiddenSize;
        private int _outputSize;

        private float[,] W1;
        private float[] b1;
        private float[,] W2;
        private float[] b2;

        private NeuralNetworkModel _model = new NeuralNetworkModel();

        #region Main

        public NeuralNet()
        {
            this._inputSize = AppConstants.INPUT_NEURONS;
            this._hiddenSize = AppConstants.HIDDEN_NEURONS;
            this._outputSize = AppConstants.OUTPUT_NEURONS;

            W1 = new float[_hiddenSize, _inputSize];
            b1 = new float[_hiddenSize];
            W2 = new float[_outputSize, _hiddenSize];
            b2 = new float[_outputSize];
        }

        public void InitializeParameters()
        {

            _model.LoadRecordWhere($"NeuralNetworkModel.ModelName = '{AppConstants.NeuralNetworkName}'");

            if (_model.ID_Model > 0)
            {
                //Load in weights
                W1 = _model.DeserializeMatrix(_model.W1, _hiddenSize, _inputSize);
                b1 = _model.DeserializeVector(_model.b1);
                W2 = _model.DeserializeMatrix(_model.W2, _outputSize, _hiddenSize);
                b2 = _model.DeserializeVector(_model.b2);
            }
            else
            {
                //Set random weights
                Random rand = new Random();

                //Weight 1
                for (int i = 0; i < _hiddenSize; i++)
                {
                    for (int j = 0; j < _inputSize; j++)
                    {
                        W1[i, j] = (float)(rand.NextDouble() - 0.5); //random value between -0.5 and 0.5
                    }
                }

                //Weight 2
                for (int i = 0; i < _outputSize; i++)
                {
                    for (int j = 0; j < _hiddenSize; j++)
                    {
                        W2[i, j] = (float)(rand.NextDouble() - 0.5);
                    }
                }

                //Give biases non zero values
                for (int i = 0; i < _hiddenSize; i++)
                {
                    b1[i] = 0.01f;
                }
                for (int i = 0; i < _outputSize; i++)
                {
                    b2[i] = 0.01f;
                }
            }
        }

        public void SaveParameters(NeuralNetworkModel model)
        {
            model.W1 = model.SerializeMatrix(W1);
            model.b1 = model.SerializeVector(b1);
            model.W2 = model.SerializeMatrix(W2); 
            model.b2 = model.SerializeVector(b2);
        }

        #endregion

        #region Analyze & Train

        public override float[] AnalyzeProbablities(bool[,] cells)
        {
            float[] inputVector = Flatten(cells);
            float[] hiddenLayer = Activation(Add(MatrixMultiply(W1, inputVector), b1));
            float[] probabilities = Softmax(Add(MatrixMultiply(W2, hiddenLayer), b2));

            return probabilities; //Returns a float of
        }

        public override int Analyze(bool[,] cells)
        {
            float[] probabilities = AnalyzeProbablities(cells);
            int prediction = Array.IndexOf(probabilities, probabilities.Max());

            //Map the index 10 to -1 for NaN
            return (prediction == 10) ? -1 : prediction;
        }

        public override void Train(bool[,] cells, int target)
        {
            //1. Preprocess the input
            int targetIndex = (target == -1) ? 10 : target; //allows us to have an output for NaN

            float[] inputVector = Flatten(cells);

            //2. Forward Pass: Compute hidden activations and output probabilities
            float[] hidden = Activation(Add(MatrixMultiply(W1, inputVector), b1));
            float[] logits = Add(MatrixMultiply(W2, hidden), b2);
            float[] probabilities = Softmax(logits);

            //3. Compute the loss
             float lost = -(float)Math.Log(probabilities[targetIndex]);

            //4. Backpropagation
            //First compute the gradient of loss w.r.t logits
            //For our model the gradient is probablities - one-hot vector
            float[] dZ2 = new float[probabilities.Length];
            for (int i = 0; i < probabilities.Length; i++)
            {
                dZ2[i] = probabilities[i];
            }
            dZ2[targetIndex] -= 1;

            //Next compute the gradients for the output layer weights (W2) and biases(b2)
            float[,] dW2 = new float[_outputSize, _hiddenSize];
            for (int i = 0; i < _outputSize; i++)
            {
                for (int j = 0; j < _hiddenSize; j++)
                {
                    dW2[i, j] = dZ2[i] * hidden[j];
                }
            }
            float[] db2 = new float[_outputSize];
            Array.Copy(dZ2, db2, _outputSize);

            //Next propage the gradients back to the the hidden layer
            float[] dHidden = new float[_hiddenSize];
            for (int i = 0; i < _hiddenSize; i++) 
            {
                float sum = 0.0f;
                for (int j = 0; j < _outputSize; j++)
                {
                    sum += W2[j, i] * dZ2[j];
                }
                dHidden[i] = sum;
            }

            //Next compute the gradient for the pre-activation of the hidden layer
            float[] dZ1 = new float[_hiddenSize];
            for (int i = 0; i < _hiddenSize; i++)
            {
                dZ1[i] = dHidden[i] * (hidden[i] > 0 ? 1 : 0);
            }

            //Finally compute gradients for the hidden layer weights (W1) and biases (b1)
            float[,] dW1 = new float[_hiddenSize, _inputSize];
            for (int i = 0; i < _hiddenSize; i++)
            {
                for (int j = 0; j < _inputSize; j++)
                {
                    dW1[i, j] = dZ1[i] * inputVector[j];
                }
            }
            float[] db1 = new float[_hiddenSize];
            Array.Copy(dZ1, db1, _hiddenSize);

            //5. Update the parameters using gradient Descent
            float learningRate = 0.01f;

            for(int i = 0; i < _outputSize; i++)
            {
                for(int j = 0; j < _hiddenSize; j++)
                {
                    W2[i, j] -= learningRate * dW2[i, j];
                }
                b2[i] -= learningRate * db2[i];
            }

            for(int i = 0; i < _hiddenSize; i++)
            {
                for(int j = 0; j < _inputSize; j++)
                {
                    W1[i, j] -= learningRate * dW1[i, j];
                }
                b1[i] -= learningRate * db1[i];
            }

        }

        #endregion

        #region Calculation

        private float[] Add(float[] vector, float[] bias)
        {
            if (vector.Length != bias.Length)
                throw new ArgumentException("Vector and bias must have the same length");

            float[] result = new float[vector.Length];

            for(int i = 0; i < vector.Length; i++)
            {
                result[i] = vector[i] + bias[i];
            }
            return result;
        }

        private float[] MatrixMultiply(float[,] matrix, float[] vector)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (vector.Length != cols)
                throw new ArgumentException("Matrix columns must match vector length");

            float[] result = new float[rows];

            for(int i = 0; i < rows; i++)
            {
                float sum = 0.0f;
                for(int j = 0; j < cols; j++)
                {
                    sum += matrix[i, j] * vector[j];
                }
                result[i] = sum;
            }
            return result;
        }

        private float[] Flatten(bool[,] cells)
        {
            int rows = cells.GetLength(0);
            int cols = cells.GetLength(1);

            float[] flatArray = new float[rows * cols];

            for(int i  = 0; i < rows; i++)
            {
                for(int j = 0; j < cols; j++)
                {
                    flatArray[i * cols + j] = cells[i, j] ? 1.0f : 0.0f;
                }
            }

            return flatArray;
        }

        private float[] Activation(float[] vector)
        {
            float[] result = new float[vector.Length];
            for(int i = 0; i < vector.Length; i++)
            {
                result[i] = Math.Max(0, vector[i]);
            }
            return result;
        }

        private float[] Softmax(float[] logits)
        {
            //Find the maximum logit for numerical stability.
            float maxLogit = logits.Max();
            float sumExp = 0.0f;
            float[] expValues = new float[logits.Length];

            //Compute exponentials for each logit and sum them up.
            for (int i = 0; i < logits.Length; i++)
            {
                expValues[i] = (float)Math.Exp(logits[i] - maxLogit);
                sumExp += expValues[i];
            }

            //Normalize each exponential value by the sum to get probabilities.
            float[] probabilities = new float[logits.Length];
            for (int i = 0; i < logits.Length; i++)
            {
                probabilities[i] = expValues[i] / sumExp;
            }

            return probabilities;
        }

        #endregion

        public override void SetBias(int layerIndex, int neuronIndex, double value)
        {
            throw new NotImplementedException();
        }

        public override void SetWeight(int matrixIndex, int rowIndex, int colIndex, double value)
        {
            throw new NotImplementedException();
        }

    }
}
