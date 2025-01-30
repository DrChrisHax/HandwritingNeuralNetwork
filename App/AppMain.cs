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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
         
            AppRoutes.Route_Main().Display(); //Display the main window

            Application.Run((Form)AppRoutes.ViewMain); //Start the main thread
        }
    }
}
