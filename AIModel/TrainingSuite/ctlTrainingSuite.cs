using HandwritingNeuralNetwork.Shared;
using System;
using System.Diagnostics;
using System.Linq;
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

        public void SetOutput(string output)
        {
            if (txtOutput.InvokeRequired)
            {
                txtOutput.Invoke(new Action<string>(SetOutput), output);
                return;
            }

            txtOutput.AppendText(output + Environment.NewLine);
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
            int classification = (int)btnTrainingNumber.Tag;
            _controller.SaveGrid(_grid.GetCells(), classification);
        }

        private async void btnTrainModel_Click(object sender, EventArgs e)
        {
            btnTrainModel.Enabled = false;
            txtOutput.AppendText("Training started…" + Environment.NewLine);

            await Task.Run(() => _controller.TrainModel());

            txtOutput.AppendText("Training finished." + Environment.NewLine);
            btnTrainModel.Enabled = true;
        }

        private void btnSaveModel_Click(object sender, EventArgs e)
        {
            this.SetOutput("Saving model.");
            Debug.WriteLine("Saving model.");
            if (_controller.SaveModel())
            {
                this.SetOutput("Model Saved Successfully!");
                Debug.WriteLine("Model Saved Successfully!");
            } else
            {
                this.SetOutput("Model failed to save.");
                Debug.WriteLine("Model failed to save.");
            }
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
