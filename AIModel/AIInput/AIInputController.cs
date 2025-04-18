using HandwritingNeuralNetwork.AIModel.AIModels;
using HandwritingNeuralNetwork.Models;
using HandwritingNeuralNetwork.Shared;
using System.Linq;


namespace HandwritingNeuralNetwork.AIModel
{
    public class AIInputController : ControllerBase<IViewAIInput>
    {
        AIModelBase _ai;

        public AIInputController(IViewAIInput view) : base(view)
        {
            


        }

        public void Analyze(bool[,] cells)
        {
            _view.SetPredictedNumber(_ai.Analyze(cells));
        }

        public bool LoadModel()
        {
            NNModel mgr = new NNModel();
            mgr = mgr.SelectWhereOrderBy(orderBy:"NNModel.LastUpdated DESC").Cast<NNModel>().ToList().First<NNModel>();
            _ai = mgr.LoadNeuralNetwork();
            return mgr.ModelId > 0 && _ai != null;
        }


    }
}
