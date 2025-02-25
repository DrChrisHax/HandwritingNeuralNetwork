using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HandwritingNeuralNetwork.AIModel
{
    public partial class DrawingGrid : UserControl
    {
        private const int gridRows = 64;
        private const int gridColumns = 64;
        private const int cellSize = 10;
        private bool[,] cells;

        public DrawingGrid()
        {
            InitializeComponent();
        }
    }
}
