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

        #region ... Events ...

        private void btnClearGrid_Click(object sender, EventArgs e)
        {
            _grid.Clear();
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {

        }

        private void btnTrain_Click(object sender, EventArgs e)
        {

        }

        private void btnTrainingNumber_Click(object sender, EventArgs e)
        {
            cntxTrainingNumbers.Show(new System.Drawing.Point(MousePosition.X, MousePosition.Y));
        }

        private void cntxTrainingNumbers_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            btnTrainingNumber.Text = e.ClickedItem.Text;
            btnTrainingNumber.Tag = e.ClickedItem.Tag;
        }

        private void pnlDrawingGrid_Paint(object sender, PaintEventArgs e)
        {
            //Called when the user draws on the grid
        }





        #endregion

        
    }
}
