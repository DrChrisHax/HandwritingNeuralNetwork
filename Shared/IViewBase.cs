using System;
using System.Windows.Forms;

namespace HandwritingNeuralNetwork.Shared
{
    public interface IViewBase
    {
        void SetController(Object controller);
        void OpenView();
        void DisplayChildView(Control control);
    }
}
