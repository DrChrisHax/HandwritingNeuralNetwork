using HandwritingNeuralNetwork.Models;
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

namespace HandwritingNeuralNetwork.AIModel.TrainingSuite
{
    public partial class ctlTrainingSuite : UserControl, IViewTrainingSuite
    {
        private TrainingSuiteController _controller;
        private DrawingGrid _grid;


        public ctlTrainingSuite()
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
            _controller = (TrainingSuiteController)controller;
        }

        #region Events

        private void btnTrainingNumber_Click(object sender, EventArgs e)
        {
            cntxTrainingNumbers.Show(MousePosition.X, MousePosition.Y);
        }

        private void cntxTrainingNumbers_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            String item = e.ClickedItem.Text;
            btnTrainingNumber.Text = item;

            if (string.Compare(item, "Not A Number") == 0)
            {
                btnTrainingNumber.Tag = -1;
            } else
            {
                btnTrainingNumber.Tag = int.Parse(item);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //TODO:
            //Add validation so the user does not accidentally save the 
            //same drawing grid data over and over
            //we need clean training data for this all to work

            int classification = (int)btnTrainingNumber.Tag;
            _controller.SaveGrid(_grid.GetCells(), classification);
        }

        private void btnFillGrid_Click(object sender, EventArgs e)
        {
            _grid.Fill();
        }

        private void btnClearGrid_Click(object sender, EventArgs e)
        {
            _grid.Clear();
        }


        #endregion

        public void _view.PopulateTraininigDataCounts(int[] counts)
        {
            if (counts == null || counts.Length != 11)
                throw new ArgumentException("Expected exactly 11 counts.", nameof(counts));

            // build a '$'‑bar for each count…
            index1.Text = string('$', counts[0]);
            index2.Text = string('$', counts[1]);
            index3.Text = string('$', counts[2]);
            index4.Text = string('$', counts[3]);
            index5.Text = string('$', counts[4]);
            index6.Text = string('$', counts[5]);
            index7.Text = string('$', counts[6]);
            index8.Text = string('$', counts[7]);
            index9.Text = string('$', counts[8]);
            index10.Text = string('$', counts[9]);
            index11.Text = string('$', counts[10]);

        }

    }
}
