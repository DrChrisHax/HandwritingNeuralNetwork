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

            if(sql_vew.ModelName == "MINST v0.1")
            {
                _ai = new MINST();
            }
            else
            {
                _ai = new NeuralNet();
            }
        }

        public int Analyze(bool[,] cells)
        {
            return _ai.Analyze(cells);
        }


    }
}
