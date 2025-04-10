using System;
using HandwritingNeuralNetwork.SQLAccess;

namespace HandwritingNeuralNetwork.Models
{
    public class NeuralNetworkWeight : model_base
    {
        public int WeightId { get; set; }
        public int ModelId { get; set; }
        public int FromLayerIndex { get; set; }
        public int ToLayerIndex { get; set; }
        public int RowIndex { get; set; }
        public int ColIndex { get; set; }
        public double WeightValue { get; set; }

        public NeuralNetworkWeight() : base() { }

        public NeuralNetworkWeight(int id) : base(id) { }
    }
}
