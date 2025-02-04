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
            DBInit DBInit = new DBInit();
            DBInit.Init();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form mainForm = (Form)AppRoutes.Route_Main().View; //Display the main window

            Application.Run(mainForm); //Start the main thread
        }
    }
}
