using HandwritingNeuralNetwork.AppMain;
using HandwritingNeuralNetwork.SQLAccess;
using System;
using System.Windows.Forms;

namespace HandwritingNeuralNetwork.App
{
    public static class AppMain
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DBInit dbInit = new DBInit();
            dbInit.Init();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            MainController mainController = AppRoutes.Route_Main();
            mainController.Display();
            Application.Run((Form)mainController.View);
        }

    }
}
