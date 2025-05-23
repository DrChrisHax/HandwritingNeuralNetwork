﻿using HandwritingNeuralNetwork.Shared;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace HandwritingNeuralNetwork.AIModel
{
    public partial class DrawingGrid : UserControl
    {
        private bool[,] _cells;

        private int _brushSize = 1;
        private Point? _lastPoint = null;

        public bool[,] GetCells() { return _cells; }

        public void SetCells(bool[,] cells)
        {
            _cells = cells;
            Invalidate(); //Force the control to redraw.
        }

        public DrawingGrid()
        {
            InitializeComponent(); //Required by the designer
            this.DoubleBuffered = true; //Reduce flicker during redraw.

            _cells = new bool[AppConstants.GRID_ROWS, AppConstants.GRID_COLUMNS];
            this.Size = new Size(AppConstants.GRID_COLUMNS * AppConstants.CELL_SIZE, AppConstants.GRID_ROWS * AppConstants.CELL_SIZE);
        }

        public void Clear()
        {
            //Reset each cell to false.
            for (int row = 0; row < AppConstants.GRID_ROWS; row++)
            {
                for (int col = 0; col < AppConstants.GRID_COLUMNS; col++)
                {
                    _cells[row, col] = false;
                }
            }
            Invalidate(); //Force the control to redraw.
        }

        public void Fill()
        {
            //Reset each cell to true.
            for (int row = 0; row < AppConstants.GRID_ROWS; row++)
            {
                for (int col = 0; col < AppConstants.GRID_COLUMNS; col++)
                {
                    _cells[row, col] = true;
                }
            }
            Invalidate(); //Force the control to redraw.
        }

        public void SetBrushSize(int newSize)
        {
            _brushSize = newSize;
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            for (int row = 0; row < AppConstants.GRID_ROWS; row++)
            {
                for (int col = 0; col < AppConstants.GRID_COLUMNS; col++)
                {
                    Rectangle rect = new Rectangle(col * AppConstants.CELL_SIZE, row * AppConstants.CELL_SIZE, AppConstants.CELL_SIZE, AppConstants.CELL_SIZE);
                    g.FillRectangle(_cells[row, col] ? Brushes.Black : Brushes.White, rect);
                    g.DrawRectangle(Pens.Gray, rect); //Draw grid lines.
                }
            }
        }

        private void SetCellAt(int x, int y)
        {
            int col = x / AppConstants.CELL_SIZE;
            int row = y / AppConstants.CELL_SIZE;

            for (int r = row; r < row + _brushSize; r++)
            {
                for (int c = col; c < col + _brushSize; c++)
                {
                    if (r >= 0 && r < AppConstants.GRID_ROWS && c >= 0 && c < AppConstants.GRID_COLUMNS)
                    {
                        if (!_cells[r, c])
                        {
                            _cells[r, c] = true;
                            Invalidate(new Rectangle(c * AppConstants.CELL_SIZE, r * AppConstants.CELL_SIZE, AppConstants.CELL_SIZE, AppConstants.CELL_SIZE));
                        }
                    }
                }
            }
        }

        private void ClearCellAt(int x, int y)
        {
            int col = x / AppConstants.CELL_SIZE;
            int row = y / AppConstants.CELL_SIZE;

            for (int r = row; r < row + _brushSize; r++)
            {
                for (int c = col; c < col + _brushSize; c++)
                {
                    if (r >= 0 && r < AppConstants.GRID_ROWS && c >= 0 && c < AppConstants.GRID_COLUMNS)
                    {
                        if (_cells[r, c])
                        {
                            _cells[r, c] = false;
                            Invalidate(new Rectangle(c * AppConstants.CELL_SIZE, r * AppConstants.CELL_SIZE, AppConstants.CELL_SIZE, AppConstants.CELL_SIZE));
                        }
                    }
                }
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            _lastPoint = e.Location;

            switch (e.Button)
            {
                case MouseButtons.Left:
                    SetCellAt(e.X, e.Y); //Fill Cell
                    break;
                case MouseButtons.Right:
                    ClearCellAt(e.X, e.Y); //Clear Cell
                    break;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if(e.Button != MouseButtons.None)
            {
                if(_lastPoint.HasValue)
                {
                    foreach (Point p in GetPointsOnLine(_lastPoint.Value, e.Location))
                    {
                        switch (e.Button)
                        {
                            case MouseButtons.Left:
                                SetCellAt(e.X, e.Y); //Fill Cell
                                break;
                            case MouseButtons.Right:
                                ClearCellAt(e.X, e.Y); //Clear Cell
                                break;
                        }
                    }
                }
                _lastPoint = e.Location;
            }    
        }

        private IEnumerable<Point> GetPointsOnLine(Point start, Point end)
        {
            int x0 = start.X;
            int y0 = start.Y;
            int x1 = end.X;
            int y1 = end.Y;
            int dx = Math.Abs(x1 - x0);
            int dy = Math.Abs(y1 - y0);
            int sx = x0 < x1 ? 1 : -1;
            int sy = y0 < y1 ? 1 : -1;
            int err = dx - dy;

            while (true)
            {
                yield return new Point(x0, y0);
                if (x0 == x1 && y0 == y1)
                    break;
                int e2 = 2 * err;
                if (e2 > -dy)
                {
                    err -= dy;
                    x0 += sx;
                }
                if (e2 < dx)
                {
                    err += dx;
                    y0 += sy;
                }
            }
        }
    }
}
