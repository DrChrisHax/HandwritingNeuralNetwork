using HandwritingNeuralNetwork.AppMain;
using HandwritingNeuralNetwork.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandwritingNeuralNetwork.AIModel
{
    public class AIInputController : ControllerBase<IViewAIInput>
    {
        private NeuralNet _ai;

        public AIInputController(IViewAIInput view) : base(view) 
        {
            _ai = new NeuralNet(AppConstants.INPUT_NEURONS, AppConstants.HIDDEN_NEURONS, AppConstants.OUTPUT_NEURONS);
        }

        public void Analyze(bool[,] cells)
        {
            _ai.Analyze(cells);
        }

        public void Train(bool[,] cells, int target)
        {
            _ai.Train(cells, target);
        }



    }
}
