using HandwritingNeuralNetwork.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandwritingNeuralNetwork.AIModel.TrainingSuite
{
    public interface IViewTrainingSuite : IViewControlBase
    {
        void PopulateTraininigDataCounts(int[] counts);
    }
}
