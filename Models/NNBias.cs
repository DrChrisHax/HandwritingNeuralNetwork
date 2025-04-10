using System;
using HandwritingNeuralNetwork.SQLAccess;

namespace HandwritingNeuralNetwork.Models
{
    public class NNBias : model_base
    {
        public int BiasId { get; set; }
        public int ModelId { get; set; }
        public int LayerIndex { get; set; }
        public int NeuronIndex { get; set; }
        public double BiasValue { get; set; }

        public NNBias() : base() { }

        public NNBias(int id) : base(id) { }
    }
}