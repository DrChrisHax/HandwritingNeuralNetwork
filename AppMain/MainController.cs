using HandwritingNeuralNetwork.AIModel;
using HandwritingNeuralNetwork.App;
using HandwritingNeuralNetwork.Models;
using HandwritingNeuralNetwork.Shared;
using System;
using System.Windows.Forms;

namespace HandwritingNeuralNetwork.AppMain
{
    public class MainController : ControllerBase<IViewMain>
    {
        private AIInputController _aiInput;
        public MainController(IViewMain view) : base(view)
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
            //Do Login
            //If successful, show AI Input

            ShowAIInput();

        }

        private void ShowAIInput()
        {
            if (_aiInput == null)
            {
                _aiInput = AppRoutes.Route_AIInput();
            }
            _view.DisplayChildView(_aiInput.View.GetControlSurface());
        }
    }
}
