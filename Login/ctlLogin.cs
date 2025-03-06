using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HandwritingNeuralNetwork.AIModel;
using HandwritingNeuralNetwork.AppMain;

namespace HandwritingNeuralNetwork.Login
{
    public partial class ctlLogin : UserControl, IVeiwLogin
    {
        private LoginController _controller;
        public ctlLogin()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {

        }

        public UserControl GetControlSurface()
        {
            return this;
        }

        public void SetController(object controller)
        {
            _controller = (LoginController)controller;
        }
    }
}
