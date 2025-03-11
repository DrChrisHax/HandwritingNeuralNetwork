using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HandwritingNeuralNetwork.AIModel.TrainingSuite
{
    public partial class ctlTrainingSuite : UserControl, IViewTrainingSuite
    {
        public ctlTrainingSuite()
        {
            InitializeComponent();
        }

        public UserControl GetControlSurface()
        {
            throw new NotImplementedException();
        }

        public void SetController(object controller)
        {
            throw new NotImplementedException();
        }
    }
}
