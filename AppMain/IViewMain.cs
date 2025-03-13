using HandwritingNeuralNetwork.Shared;
using System;
using System.Windows.Forms;

namespace HandwritingNeuralNetwork.AppMain
{
    public interface IViewMain : IViewFormBase
    {
        void EnableNavigation(bool enable, bool isAdmin);
    }
}
