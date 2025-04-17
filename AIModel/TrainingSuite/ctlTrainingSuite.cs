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

            // Define the character for each bucket: '0'–'9', then 'n'
            
            index1.Text = $"{counts[0]} number of records";
            index2.Text = $"{counts[1]} number of records";
            index3.Text = $"{counts[2]} number of records";
            index4.Text = $"{counts[3]} number of records";
            index5.Text = $"{counts[4]} number of records";
            index6.Text = $"{counts[5]} number of records";
            index7.Text = $"{counts[6]} number of records";
            index8.Text = $"{counts[7]} number of records";
            index9.Text = $"{counts[8]} number of records";
            index10.Text = $"{counts[9]} number of records";
            index11.Text = $"{counts[10]} number of n records";
        }

    }
}
