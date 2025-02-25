using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HandwritingNeuralNetwork.AIModel
{
    public partial class DrawingGrid : UserControl
    {
        private const int GRID_ROWS = 64;
        private const int GRID_COLUMNS = 64;
        private const int CELL_SIZE = 5;
        private bool[,] cells;

        public DrawingGrid()
        {
            InitializeComponent(); // Required by the designer
            this.DoubleBuffered = true; // Reduce flicker during redraw.

            cells = new bool[GRID_ROWS, GRID_COLUMNS];
            this.Size = new Size(GRID_COLUMNS * CELL_SIZE, GRID_ROWS * CELL_SIZE);
        }

        public void Clear()
        {
            // Reset each cell to false.
            for (int row = 0; row < GRID_ROWS; row++)
            {
                for (int col = 0; col < GRID_COLUMNS; col++)
                {
                    cells[row, col] = false;
                }
            }
            Invalidate(); //Force the control to redraw.
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            for (int row = 0; row < GRID_ROWS; row++)
            {
                for (int col = 0; col < GRID_COLUMNS; col++)
                {
                    Rectangle rect = new Rectangle(col * CELL_SIZE, row * CELL_SIZE, CELL_SIZE, CELL_SIZE);
                    g.FillRectangle(cells[row, col] ? Brushes.Black : Brushes.White, rect);
                    g.DrawRectangle(Pens.Gray, rect); // Draw grid lines.
                }
            }
        }

        // Helper method to set a cell to drawn (true) if it's not already.
        private void SetCellAt(int x, int y)
        {
            int col = x / CELL_SIZE;
            int row = y / CELL_SIZE;

            if (row >= 0 && row < GRID_ROWS && col >= 0 && col < GRID_COLUMNS)
            {
                if (!cells[row, col])
                {
                    cells[row, col] = true;
                    Invalidate(new Rectangle(col * CELL_SIZE, row * CELL_SIZE, CELL_SIZE, CELL_SIZE));
                }
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.Button == MouseButtons.Left)
            {
                SetCellAt(e.X, e.Y);
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            // While dragging with the left mouse button, draw on the grid.
            if (e.Button == MouseButtons.Left)
            {
                SetCellAt(e.X, e.Y);
            }
        }
    }
}
