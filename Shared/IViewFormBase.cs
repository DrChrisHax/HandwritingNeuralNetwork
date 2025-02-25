using System;
using System.Windows.Forms;

namespace HandwritingNeuralNetwork.Shared
{
    public interface IViewFormBase : IViewBase
    {
        void OpenView();
        void DisplayChildView(Control control);
    }
}
