using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandwritingNeuralNetwork.AIModel.AIModels
{
    public abstract class AIModelBase
    {
        string modelName;
        bool canBeTrained;

        public AIModelBase() { }

        public abstract float[] AnalyzeProbablities(bool[,] cells);
        public abstract int Analyze(bool[,] cells);
        public abstract void Train(bool[,] cells, int target);


    }
}
