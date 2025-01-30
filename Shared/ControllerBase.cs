using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandwritingNeuralNetwork.Shared
{
    public abstract class ControllerBase<T> where T : IViewBase
    {
        protected T _view;

        public ControllerBase()
        {
        }

        public ControllerBase(T view)
        {
            _view = view;
            _view.SetController(this);
        }

        public T View => _view;

        public string ControllerName => GetType().Name;
    }
}
