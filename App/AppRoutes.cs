using HandwritingNeuralNetwork.AppMain;

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

    }
}
