using HandwritingNeuralNetwork.AIModel;
using HandwritingNeuralNetwork.AIModel.TrainingSuite;
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
        private LoginController _login;
        private AIInputController _aiInput;
        private TrainingSuiteController _trainingSuite;

        public MainController(IViewMain view) : base(view)
        {

        }

        #region Routing

        public void Display()
        {
            _view.SetController(this);
            _view.OpenView();
            ShowLogin();
        }

        public void ShowLogin()
        {
            if(_login == null)
            {
                _login = AppRoutes.Route_Login();

                _login.LoginSuccessful += OnLoginSuccessful;
            }
            AppSession.systemUser = null;
            _view.DisplayChildView(_login.View.GetControlSurface());
        }

        public void ShowAIInput()
        {
            if (_aiInput == null)
            {
                _aiInput = AppRoutes.Route_AIInput();
            }
            _view.DisplayChildView(_aiInput.View.GetControlSurface());
        }

        public void ShowTrainingSuite()
        {
            if (_trainingSuite == null)
            {
                _trainingSuite = AppRoutes.Route_TrainingSuite();
            }
            _view.DisplayChildView(_trainingSuite.View.GetControlSurface());
        }

        #endregion

        #region Control Events

        public void OnLoginSuccessful(object sender, EventArgs e)
        {
            View.EnableNavigation(true, AppSession.systemUser.IsAdmin);
            ShowAIInput();
        }

        public void Logout()
        {
            AppSession.systemUser = null;
            ShowLogin();
        }


        #endregion

    }
}
