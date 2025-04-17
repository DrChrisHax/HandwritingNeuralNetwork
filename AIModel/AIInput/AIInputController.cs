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
            


        }

        public void Analyze(bool[,] cells)
        {

        }


    }
}
