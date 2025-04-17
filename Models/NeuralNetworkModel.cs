
using Newtonsoft.Json;
using System;

namespace HandwritingNeuralNetwork.Models
{

    /*
     * DEPRECATED
     */
    public class NeuralNetworkModel : model_base
    {
        public int ID_Model { get; set; }
        public string ModelName { get; set; }
        public int InputSize { get; set; }
        public int HiddenSize { get; set; }
        public int OutputSize { get; set; }

        //Serialized parameters 
        public string W1 { get; set; }  //Serialized 2D array for weights from input to hidden layer
        public string b1 { get; set; }  //Serialized 1D array for biases of hidden layer
        public string W2{ get; set; }  //Serialized 2D array for weights from hidden to output layer
        public string b2 { get; set; }  //Serialized 1D array for biases of output layer

        public DateTime LastUpdated { get; set; }

        public NeuralNetworkModel() {}
        public NeuralNetworkModel(int id) : base(id) { }


        #region Serialization Functions

        public string SerializeMatrix(float[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            float[][] output = new float[rows][];
            for (int i = 0; i < rows; i++)
            {
                output[i] = new float[cols];
                for (int j = 0; j < cols; j++)
                {
                    output[i][j] = matrix[i, j];
                }
            }
            return JsonConvert.SerializeObject(output);
        }

        public float[,] DeserializeMatrix(string json, int rows, int cols)
        {
            float[][] input = JsonConvert.DeserializeObject<float[][]>(json);
            float[,] matrix = new float[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = input[i][j];
                }
            }
            return matrix;
        }

        public string SerializeVector(float[] vector)
        {
            return JsonConvert.SerializeObject(vector);
        }

        public float[] DeserializeVector(string json)
        {
            return JsonConvert.DeserializeObject<float[]>(json);
        }

        #endregion

    }
}
