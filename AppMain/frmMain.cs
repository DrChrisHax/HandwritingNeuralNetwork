using HandwritingNeuralNetwork.AppMain;
using HandwritingNeuralNetwork.Shared;
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

        public void DisplayChildView(Control control)
        {
            ControlUtilities.PanelLoad(MainPanel, control);
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
