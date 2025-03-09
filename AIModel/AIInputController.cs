using HandwritingNeuralNetwork.AppMain;
using HandwritingNeuralNetwork.Models;
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
        private NeuralNetworkModel _model = new NeuralNetworkModel();
        private NeuralNet _ai;

        public AIInputController(IViewAIInput view) : base(view) 
        {
            _ai = new NeuralNet(AppConstants.INPUT_NEURONS, AppConstants.HIDDEN_NEURONS, AppConstants.OUTPUT_NEURONS);

            _model.LoadRecordWhere($"NeuralNetworkModel.ModelName = '{AppConstants.NeuralNetworkName}'");

            if(_model.ID_Model > 0)
            {
                _ai.InitializeParameters(_model);
            }

        }

        public void Analyze(bool[,] cells)
        {
            int result = _ai.Analyze(cells);
            View.SetPredictedNumber(result);
            
        }

        public void Train(bool[,] cells, int target)
        {
            _ai.Train(cells, target);
            _ai.SaveParameters(_model);
            SaveModel();
        }

        private void SaveModel()
        {
            _model.ModelName = AppConstants.NeuralNetworkName;
            _model.InputSize = AppConstants.INPUT_NEURONS;
            _model.HiddenSize = AppConstants.HIDDEN_NEURONS;
            _model.OutputSize = AppConstants.OUTPUT_NEURONS;
            _model.LastUpdated = DateTime.Now;

            if (_model.ID_Model > 0) 
            {
                _model.UpdateRecord();
            } else
            {
                _model.AddRecord();
            }

        }


    }
}
