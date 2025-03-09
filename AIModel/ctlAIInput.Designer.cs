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
            this.components = new System.ComponentModel.Container();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnAnalyze = new System.Windows.Forms.Button();
            this.pnlDrawingGrid = new System.Windows.Forms.Panel();
            this.btnClearGrid = new System.Windows.Forms.Button();
            this.btnTrain = new System.Windows.Forms.Button();
            this.btnTrainingNumber = new System.Windows.Forms.Button();
            this.cntxTrainingNumbers = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tool0 = new System.Windows.Forms.ToolStripMenuItem();
            this.tool1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tool2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tool3 = new System.Windows.Forms.ToolStripMenuItem();
            this.tool4 = new System.Windows.Forms.ToolStripMenuItem();
            this.tool5 = new System.Windows.Forms.ToolStripMenuItem();
            this.tool6 = new System.Windows.Forms.ToolStripMenuItem();
            this.tool7 = new System.Windows.Forms.ToolStripMenuItem();
            this.tool8 = new System.Windows.Forms.ToolStripMenuItem();
            this.tool9 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolNotANumber = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTrainAs = new System.Windows.Forms.Label();
            this.lblPrediction = new System.Windows.Forms.Label();
            this.btnFillGrid = new System.Windows.Forms.Button();
            this.cntxTrainingNumbers.SuspendLayout();
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
            // btnTrain
            // 
            this.btnTrain.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnTrain.AutoSize = true;
            this.btnTrain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnTrain.BackColor = System.Drawing.SystemColors.Control;
            this.btnTrain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTrain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTrain.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrain.Location = new System.Drawing.Point(340, 292);
            this.btnTrain.Name = "btnTrain";
            this.btnTrain.Size = new System.Drawing.Size(68, 33);
            this.btnTrain.TabIndex = 4;
            this.btnTrain.Text = "Train";
            this.btnTrain.UseMnemonic = false;
            this.btnTrain.UseVisualStyleBackColor = false;
            this.btnTrain.Click += new System.EventHandler(this.btnTrain_Click);
            // 
            // btnTrainingNumber
            // 
            this.btnTrainingNumber.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnTrainingNumber.AutoSize = true;
            this.btnTrainingNumber.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnTrainingNumber.BackColor = System.Drawing.SystemColors.Control;
            this.btnTrainingNumber.ContextMenuStrip = this.cntxTrainingNumbers;
            this.btnTrainingNumber.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTrainingNumber.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTrainingNumber.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrainingNumber.Location = new System.Drawing.Point(453, 249);
            this.btnTrainingNumber.Name = "btnTrainingNumber";
            this.btnTrainingNumber.Size = new System.Drawing.Size(33, 33);
            this.btnTrainingNumber.TabIndex = 5;
            this.btnTrainingNumber.Tag = "0";
            this.btnTrainingNumber.Text = "0";
            this.btnTrainingNumber.UseMnemonic = false;
            this.btnTrainingNumber.UseVisualStyleBackColor = false;
            this.btnTrainingNumber.Click += new System.EventHandler(this.btnTrainingNumber_Click);
            // 
            // cntxTrainingNumbers
            // 
            this.cntxTrainingNumbers.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cntxTrainingNumbers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tool0,
            this.tool1,
            this.tool2,
            this.tool3,
            this.tool4,
            this.tool5,
            this.tool6,
            this.tool7,
            this.tool8,
            this.tool9,
            this.toolNotANumber});
            this.cntxTrainingNumbers.Name = "cntxTrainingNumbers";
            this.cntxTrainingNumbers.Size = new System.Drawing.Size(176, 268);
            this.cntxTrainingNumbers.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.cntxTrainingNumbers_ItemClicked);
            // 
            // tool0
            // 
            this.tool0.Name = "tool0";
            this.tool0.Size = new System.Drawing.Size(175, 24);
            this.tool0.Tag = "0";
            this.tool0.Text = "0";
            // 
            // tool1
            // 
            this.tool1.Name = "tool1";
            this.tool1.Size = new System.Drawing.Size(175, 24);
            this.tool1.Tag = "1";
            this.tool1.Text = "1";
            // 
            // tool2
            // 
            this.tool2.Name = "tool2";
            this.tool2.Size = new System.Drawing.Size(175, 24);
            this.tool2.Tag = "2";
            this.tool2.Text = "2";
            // 
            // tool3
            // 
            this.tool3.Name = "tool3";
            this.tool3.Size = new System.Drawing.Size(175, 24);
            this.tool3.Tag = "3";
            this.tool3.Text = "3";
            // 
            // tool4
            // 
            this.tool4.Name = "tool4";
            this.tool4.Size = new System.Drawing.Size(175, 24);
            this.tool4.Tag = "4";
            this.tool4.Text = "4";
            // 
            // tool5
            // 
            this.tool5.Name = "tool5";
            this.tool5.Size = new System.Drawing.Size(175, 24);
            this.tool5.Tag = "5";
            this.tool5.Text = "5";
            // 
            // tool6
            // 
            this.tool6.Name = "tool6";
            this.tool6.Size = new System.Drawing.Size(175, 24);
            this.tool6.Tag = "6";
            this.tool6.Text = "6";
            // 
            // tool7
            // 
            this.tool7.Name = "tool7";
            this.tool7.Size = new System.Drawing.Size(175, 24);
            this.tool7.Tag = "7";
            this.tool7.Text = "7";
            // 
            // tool8
            // 
            this.tool8.Name = "tool8";
            this.tool8.Size = new System.Drawing.Size(175, 24);
            this.tool8.Tag = "8";
            this.tool8.Text = "8";
            // 
            // tool9
            // 
            this.tool9.Name = "tool9";
            this.tool9.Size = new System.Drawing.Size(175, 24);
            this.tool9.Tag = "9";
            this.tool9.Text = "9";
            // 
            // toolNotANumber
            // 
            this.toolNotANumber.Name = "toolNotANumber";
            this.toolNotANumber.Size = new System.Drawing.Size(175, 24);
            this.toolNotANumber.Tag = "-1";
            this.toolNotANumber.Text = "Not A Number";
            // 
            // lblTrainAs
            // 
            this.lblTrainAs.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTrainAs.AutoSize = true;
            this.lblTrainAs.Location = new System.Drawing.Point(335, 250);
            this.lblTrainAs.Name = "lblTrainAs";
            this.lblTrainAs.Size = new System.Drawing.Size(112, 27);
            this.lblTrainAs.TabIndex = 6;
            this.lblTrainAs.Text = "Train As:";
            // 
            // lblPrediction
            // 
            this.lblPrediction.AutoSize = true;
            this.lblPrediction.Location = new System.Drawing.Point(15, 117);
            this.lblPrediction.Name = "lblPrediction";
            this.lblPrediction.Size = new System.Drawing.Size(283, 27);
            this.lblPrediction.TabIndex = 7;
            this.lblPrediction.Text = "The number below is a 0";
            // 
            // btnFillGrid
            // 
            this.btnFillGrid.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnFillGrid.AutoSize = true;
            this.btnFillGrid.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnFillGrid.BackColor = System.Drawing.SystemColors.Control;
            this.btnFillGrid.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFillGrid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFillGrid.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFillGrid.Location = new System.Drawing.Point(451, 670);
            this.btnFillGrid.Name = "btnFillGrid";
            this.btnFillGrid.Size = new System.Drawing.Size(91, 33);
            this.btnFillGrid.TabIndex = 8;
            this.btnFillGrid.Text = "Fill Grid";
            this.btnFillGrid.UseMnemonic = false;
            this.btnFillGrid.UseVisualStyleBackColor = false;
            this.btnFillGrid.Click += new System.EventHandler(this.btnFillGrid_Click);
            // 
            // ctlAIInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.btnFillGrid);
            this.Controls.Add(this.lblPrediction);
            this.Controls.Add(this.lblTrainAs);
            this.Controls.Add(this.btnTrainingNumber);
            this.Controls.Add(this.btnTrain);
            this.Controls.Add(this.btnClearGrid);
            this.Controls.Add(this.pnlDrawingGrid);
            this.Controls.Add(this.btnAnalyze);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ctlAIInput";
            this.Size = new System.Drawing.Size(1000, 1000);
            this.cntxTrainingNumbers.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnAnalyze;
        private System.Windows.Forms.Panel pnlDrawingGrid;
        private System.Windows.Forms.Button btnClearGrid;
        private System.Windows.Forms.Button btnTrain;
        private System.Windows.Forms.Button btnTrainingNumber;
        private System.Windows.Forms.Label lblTrainAs;
        private System.Windows.Forms.Label lblPrediction;
        private System.Windows.Forms.ContextMenuStrip cntxTrainingNumbers;
        private System.Windows.Forms.ToolStripMenuItem tool0;
        private System.Windows.Forms.ToolStripMenuItem tool1;
        private System.Windows.Forms.ToolStripMenuItem tool2;
        private System.Windows.Forms.ToolStripMenuItem tool3;
        private System.Windows.Forms.ToolStripMenuItem tool4;
        private System.Windows.Forms.ToolStripMenuItem tool5;
        private System.Windows.Forms.ToolStripMenuItem tool6;
        private System.Windows.Forms.ToolStripMenuItem tool7;
        private System.Windows.Forms.ToolStripMenuItem tool8;
        private System.Windows.Forms.ToolStripMenuItem tool9;
        private System.Windows.Forms.ToolStripMenuItem toolNotANumber;
        private System.Windows.Forms.Button btnFillGrid;
    }
}
