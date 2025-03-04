namespace HandwritingNeuralNetwork.AIModel
{
    partial class ctlAIInput
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnAnalyze = new System.Windows.Forms.Button();
            this.pnlDrawingGrid = new System.Windows.Forms.Panel();
            this.btnClearGrid = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(15, 15);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(5);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(330, 27);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Handwriting Neural Network";
            // 
            // btnAnalyze
            // 
            this.btnAnalyze.AutoSize = true;
            this.btnAnalyze.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAnalyze.BackColor = System.Drawing.SystemColors.Control;
            this.btnAnalyze.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAnalyze.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnalyze.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnalyze.Location = new System.Drawing.Point(15, 60);
            this.btnAnalyze.Name = "btnAnalyze";
            this.btnAnalyze.Size = new System.Drawing.Size(205, 33);
            this.btnAnalyze.TabIndex = 1;
            this.btnAnalyze.Text = "Analyze Handwriting";
            this.btnAnalyze.UseMnemonic = false;
            this.btnAnalyze.UseVisualStyleBackColor = false;
            this.btnAnalyze.Click += new System.EventHandler(this.btnAnalyze_Click);
            // 
            // pnlDrawingGrid
            // 
            this.pnlDrawingGrid.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlDrawingGrid.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pnlDrawingGrid.Location = new System.Drawing.Point(340, 340);
            this.pnlDrawingGrid.Margin = new System.Windows.Forms.Padding(0);
            this.pnlDrawingGrid.Name = "pnlDrawingGrid";
            this.pnlDrawingGrid.Size = new System.Drawing.Size(321, 321);
            this.pnlDrawingGrid.TabIndex = 2;
            this.pnlDrawingGrid.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlDrawingGrid_Paint);
            // 
            // btnClearGrid
            // 
            this.btnClearGrid.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClearGrid.AutoSize = true;
            this.btnClearGrid.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClearGrid.BackColor = System.Drawing.SystemColors.Control;
            this.btnClearGrid.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearGrid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearGrid.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearGrid.Location = new System.Drawing.Point(548, 670);
            this.btnClearGrid.Name = "btnClearGrid";
            this.btnClearGrid.Size = new System.Drawing.Size(113, 33);
            this.btnClearGrid.TabIndex = 3;
            this.btnClearGrid.Text = "Clear Grid";
            this.btnClearGrid.UseMnemonic = false;
            this.btnClearGrid.UseVisualStyleBackColor = false;
            this.btnClearGrid.Click += new System.EventHandler(this.btnClearGrid_Click);
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(242, 60);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(205, 33);
            this.button1.TabIndex = 4;
            this.button1.Text = "Analyze Handwriting";
            this.button1.UseMnemonic = false;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // ctlAIInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnClearGrid);
            this.Controls.Add(this.pnlDrawingGrid);
            this.Controls.Add(this.btnAnalyze);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ctlAIInput";
            this.Size = new System.Drawing.Size(1000, 1000);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnAnalyze;
        private System.Windows.Forms.Panel pnlDrawingGrid;
        private System.Windows.Forms.Button btnClearGrid;
        private System.Windows.Forms.Button button1;
    }
}
