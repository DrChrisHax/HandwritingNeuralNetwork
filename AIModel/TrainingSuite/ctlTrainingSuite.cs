using HandwritingNeuralNetwork.Shared;
using System;
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

            btnTrainingNumber.Tag = 0; //Prevents errors
        }

        public UserControl GetControlSurface()
        {
            return this;
        }

        public void SetController(object controller)
        {
            _controller = (TrainingSuiteController)controller;
        }

        public void PopulateTraininigDataCounts(int[] counts)
        {
            if (counts == null || counts.Length != 11)
                throw new ArgumentException("Expected exactly 11 counts.", nameof(counts));

            // Define the character for each bucket: '0'–'9', then 'n'

            count0.Text = $"{counts[0]} instances of digit 0 records";
            count1.Text = $"{counts[1]} instances of digit 1 records";
            count2.Text = $"{counts[2]} instances of digit 2 records";
            count3.Text = $"{counts[3]} instances of digit 3 records";
            count4.Text = $"{counts[4]} instances of digit 4 records";
            count5.Text = $"{counts[5]} instances of digit 5 records";
            count6.Text = $"{counts[6]} instances of digit 6 records";
            count7.Text = $"{counts[7]} instances of digit 7 records";
            count8.Text = $"{counts[8]} instances of digit 8 records";
            count9.Text = $"{counts[9]} instances of digit 9 records";
            countNaN.Text = $"{counts[10]} instances Not a Number of records";
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

        private void btnTrainModel_Click(object sender, EventArgs e)
        {
            _controller.TrainModel();
        }

        private void btnSaveModel_Click(object sender, EventArgs e)
        {
            _controller.SaveModel();
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

        

        
    }
}
