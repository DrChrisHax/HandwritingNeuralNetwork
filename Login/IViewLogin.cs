using HandwritingNeuralNetwork.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandwritingNeuralNetwork.Login
{
    public interface IViewLogin : IViewControlBase
    {
        string UserName { get; }
        string Password { get; }
        bool NewAccount { get; }

        void ShowWarningMessage(string message);
    }
}
