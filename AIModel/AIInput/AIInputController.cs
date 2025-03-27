using HandwritingNeuralNetwork.AIModel.AIModels;
using HandwritingNeuralNetwork.Models;
using HandwritingNeuralNetwork.Shared;


namespace HandwritingNeuralNetwork.AIModel
{
    public class AIInputController : ControllerBase<IViewAIInput>
    {
        AIModelBase _ai;

        public AIInputController(IViewAIInput view) : base(view)
        {
            AIModelTable sql_vew = new AIModelTable();
            sql_vew.GetDeployed();

            if(sql_vew.ModelName == "HWNN v0.1")
            {
                _ai = new NeuralNet();
            }
            else
            {
                _ai = new MNIST();     
            }
        }

        public void Analyze(bool[,] cells)
        {
            View.SetPredictedNumber(_ai.Analyze(cells));
        }


    }
}
