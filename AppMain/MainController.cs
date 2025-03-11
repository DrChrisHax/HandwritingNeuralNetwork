using HandwritingNeuralNetwork.AIModel;
using HandwritingNeuralNetwork.App;
using HandwritingNeuralNetwork.Login;
using HandwritingNeuralNetwork.Models;
using HandwritingNeuralNetwork.Shared;
using System;
using System.Windows.Forms;

namespace HandwritingNeuralNetwork.AppMain
{
    public class MainController : ControllerBase<IViewMain>
    {
        private LoginController _loginController;
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
            if(_loginController == null)
            {
                _loginController = AppRoutes.Route_Login();

                _loginController.LoginSuccessful += OnLoginSuccessful;
            }
            _view.DisplayChildView(_loginController.View.GetControlSurface());
        }

        private void OnLoginSuccessful(object sender, EventArgs e)
        {
            //Enable navigation here
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
