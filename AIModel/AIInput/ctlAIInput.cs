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

namespace HandwritingNeuralNetwork.AIModel
{
    public partial class ctlAIInput : UserControl, IViewAIInput
    {
        private AIInputController _controller; 
        private DrawingGrid _grid;

        public ctlAIInput()
        {
            InitializeComponent();

            _grid = new DrawingGrid();
            ControlUtilities.PanelLoad(pnlDrawingGrid, _grid);

        }

        public UserControl GetControlSurface()
        {
            return this;
        }

        public void SetController(object controller)
        {
            _controller = (AIInputController)controller;
        }

        public void SetPredictedNumber(int prediction)
        {
            if (prediction > 0) 
            {
                lblPrediction.Text = $"The number below is a {prediction}.";
            }
            else
            {
                lblPrediction.Text = "The symbol below is not a number.";
            }
        }

        #region ... Events ...

        private void btnClearGrid_Click(object sender, EventArgs e)
        {
            _grid.Clear();
        }

        private void btnFillGrid_Click(object sender, EventArgs e)
        {
            _grid.Fill();
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            _controller.Analyze(_grid.GetCells());
        }

        private void pnlDrawingGrid_Paint(object sender, PaintEventArgs e)
        {
            //Called when the user draws on the grid
        }



        #endregion

        private void btnLoadModel_Click(object sender, EventArgs e)
        {

        }
    }
}
