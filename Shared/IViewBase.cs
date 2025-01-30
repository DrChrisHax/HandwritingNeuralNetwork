using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandwritingNeuralNetwork.Shared
{
    public interface IViewBase
    {
        void SetController(Object controller);
        void OpenView();
        void DisplayChildView(Object child);
    }
}
