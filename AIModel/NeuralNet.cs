using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandwritingNeuralNetwork.AIModel
{
    public class NeuralNet
    {
        private int _inputSize;
        private int _hiddenSize;
        private int _outputSize;

        private float[,] W1;
        private float[] b1;
        private float[,] W2;
        private float[] b2;

        public NeuralNet(int inputSize, int hiddenSize, int outputSize)
        {
            this._inputSize = inputSize;
            this._hiddenSize = hiddenSize;
            this._outputSize = outputSize;

            W1 = new float[hiddenSize, inputSize];
            b1 = new float[hiddenSize];
            W2 = new float[outputSize, hiddenSize];
            b2 = new float[outputSize];

            InitializeParameters(); //This will pull data from the DB if it exists
        }

        public float[] Analyze()
        {
            return null;
        }

        private void InitializeParameters()
        {

        }

    }
}
