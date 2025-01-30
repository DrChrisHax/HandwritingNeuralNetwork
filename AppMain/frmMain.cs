using HandwritingNeuralNetwork.AppMain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HandwritingNeuralNetwork
{
    public partial class frmMain : Form, IViewMain
    {
        private MainController _controller;

        public frmMain()
        {
            InitializeComponent();
        }

        public void DisplayChildView(object child)
        {
            throw new NotImplementedException();
        }

        public void OpenView()
        {
            this.Show();
        }

        public void SetController(object controller)
        {
            _controller = (MainController)controller;
        }
    }
}
