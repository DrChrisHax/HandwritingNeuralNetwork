using HandwritingNeuralNetwork.Shared;


namespace HandwritingNeuralNetwork.AIModel
{
    public interface IViewAIInput : IViewControlBase
    {
        void SetPredictedNumber(int prediction);
    }
}
