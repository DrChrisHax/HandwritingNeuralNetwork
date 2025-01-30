using HandwritingNeuralNetwork.Shared;

namespace HandwritingNeuralNetwork.AppMain
{
    public class MainController : ControllerBase<IViewMain>
    {
        public MainController(IViewMain viewInstance) : base(viewInstance)
        {

        }

        public void Display()
        {
            _view.SetController(this);
            _view.OpenView();
            ShowLogin();
        }

        private void ShowLogin()
        {

        }

    }
}
