using System;
using System.Windows.Forms;

namespace HandwritingNeuralNetwork.Shared
{
    public interface IViewControlBase : IViewBase
    {
        UserControl GetControlSurface();
    }
}
