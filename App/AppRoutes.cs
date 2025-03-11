using HandwritingNeuralNetwork.AIModel;
using HandwritingNeuralNetwork.AppMain;
using HandwritingNeuralNetwork.Login;

namespace HandwritingNeuralNetwork.App
{
    public static class AppRoutes
    {

        public static IViewMain ViewMain { get; set; }
        public static MainController Route_Main()
        {
            var view = ViewMain ?? new frmMain();
            return new MainController(view);
        }

        public static IViewLogin ViewLogin { get; set; }
        public static LoginController Route_Login()
        {
            var view = ViewLogin ?? new ctlLogin();
            return new LoginController(view);
        }

        public static IViewAIInput ViewAIInput { get; set; }
        public static AIInputController Route_AIInput()
        {
            var view = ViewAIInput ?? new ctlAIInput();
            return new AIInputController(view);
        }


    }
}
