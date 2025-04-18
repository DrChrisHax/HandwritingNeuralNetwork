namespace HandwritingNeuralNetwork.AIModel.TrainingSuite
{
    partial class ctlTrainingSuite
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
            this.pnlDrawingGrid = new System.Windows.Forms.Panel();
            this.btnClearGrid = new System.Windows.Forms.Button();
            this.btnFillGrid = new System.Windows.Forms.Button();
            this.lblTrainAs = new System.Windows.Forms.Label();
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
            this.btnSave = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.countNaN = new System.Windows.Forms.Label();
            this.count9 = new System.Windows.Forms.Label();
            this.count8 = new System.Windows.Forms.Label();
            this.count7 = new System.Windows.Forms.Label();
            this.count4 = new System.Windows.Forms.Label();
            this.count6 = new System.Windows.Forms.Label();
            this.count5 = new System.Windows.Forms.Label();
            this.count3 = new System.Windows.Forms.Label();
            this.count2 = new System.Windows.Forms.Label();
            this.count1 = new System.Windows.Forms.Label();
            this.count0 = new System.Windows.Forms.Label();
            this.btnTrainModel = new System.Windows.Forms.Button();
            this.btnSaveModel = new System.Windows.Forms.Button();
            this.cntxTrainingNumbers.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDrawingGrid
            // 
            this.pnlDrawingGrid.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlDrawingGrid.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pnlDrawingGrid.Location = new System.Drawing.Point(340, 340);
            this.pnlDrawingGrid.Margin = new System.Windows.Forms.Padding(0);
            this.pnlDrawingGrid.Name = "pnlDrawingGrid";
            this.pnlDrawingGrid.Size = new System.Drawing.Size(321, 321);
            this.pnlDrawingGrid.TabIndex = 3;
            // 
            // btnClearGrid
            // 
            this.btnClearGrid.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClearGrid.AutoSize = true;
            this.btnClearGrid.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClearGrid.BackColor = System.Drawing.SystemColors.Control;
            this.btnClearGrid.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearGrid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearGrid.Location = new System.Drawing.Point(557, 673);
            this.btnClearGrid.Name = "btnClearGrid";
            this.btnClearGrid.Size = new System.Drawing.Size(104, 34);
            this.btnClearGrid.TabIndex = 4;
            this.btnClearGrid.Text = "Clear Grid";
            this.btnClearGrid.UseMnemonic = false;
            this.btnClearGrid.UseVisualStyleBackColor = false;
            this.btnClearGrid.Click += new System.EventHandler(this.btnClearGrid_Click);
            // 
            // btnFillGrid
            // 
            this.btnFillGrid.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnFillGrid.AutoSize = true;
            this.btnFillGrid.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnFillGrid.BackColor = System.Drawing.SystemColors.Control;
            this.btnFillGrid.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFillGrid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFillGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFillGrid.Location = new System.Drawing.Point(467, 673);
            this.btnFillGrid.Name = "btnFillGrid";
            this.btnFillGrid.Size = new System.Drawing.Size(84, 34);
            this.btnFillGrid.TabIndex = 9;
            this.btnFillGrid.Text = "Fill Grid";
            this.btnFillGrid.UseMnemonic = false;
            this.btnFillGrid.UseVisualStyleBackColor = false;
            this.btnFillGrid.Click += new System.EventHandler(this.btnFillGrid_Click);
            // 
            // lblTrainAs
            // 
            this.lblTrainAs.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTrainAs.AutoSize = true;
            this.lblTrainAs.Location = new System.Drawing.Point(335, 250);
            this.lblTrainAs.Name = "lblTrainAs";
            this.lblTrainAs.Size = new System.Drawing.Size(108, 29);
            this.lblTrainAs.TabIndex = 10;
            this.lblTrainAs.Text = "Train As:";
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
            this.btnTrainingNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrainingNumber.Location = new System.Drawing.Point(453, 249);
            this.btnTrainingNumber.Name = "btnTrainingNumber";
            this.btnTrainingNumber.Size = new System.Drawing.Size(32, 34);
            this.btnTrainingNumber.TabIndex = 11;
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
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSave.AutoSize = true;
            this.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSave.BackColor = System.Drawing.SystemColors.Control;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(340, 292);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(63, 34);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.UseMnemonic = false;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(15, 15);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(5);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(163, 29);
            this.lblTitle.TabIndex = 13;
            this.lblTitle.Text = "Training Suite";
            // 
            // countNaN
            // 
            this.countNaN.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.countNaN.AutoSize = true;
            this.countNaN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.countNaN.Location = new System.Drawing.Point(664, 510);
            this.countNaN.Name = "countNaN";
            this.countNaN.Size = new System.Drawing.Size(71, 17);
            this.countNaN.TabIndex = 10;
            this.countNaN.Text = "countNaN";
            // 
            // count9
            // 
            this.count9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.count9.AutoSize = true;
            this.count9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.count9.Location = new System.Drawing.Point(664, 493);
            this.count9.Name = "count9";
            this.count9.Size = new System.Drawing.Size(51, 17);
            this.count9.TabIndex = 9;
            this.count9.Text = "count9";
            // 
            // count8
            // 
            this.count8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.count8.AutoSize = true;
            this.count8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.count8.Location = new System.Drawing.Point(664, 476);
            this.count8.Name = "count8";
            this.count8.Size = new System.Drawing.Size(51, 17);
            this.count8.TabIndex = 8;
            this.count8.Text = "count8";
            // 
            // count7
            // 
            this.count7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.count7.AutoSize = true;
            this.count7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.count7.Location = new System.Drawing.Point(664, 459);
            this.count7.Name = "count7";
            this.count7.Size = new System.Drawing.Size(51, 17);
            this.count7.TabIndex = 7;
            this.count7.Text = "count7";
            // 
            // count4
            // 
            this.count4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.count4.AutoSize = true;
            this.count4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.count4.Location = new System.Drawing.Point(664, 408);
            this.count4.Name = "count4";
            this.count4.Size = new System.Drawing.Size(51, 17);
            this.count4.TabIndex = 6;
            this.count4.Text = "count4";
            // 
            // count6
            // 
            this.count6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.count6.AutoSize = true;
            this.count6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.count6.Location = new System.Drawing.Point(664, 442);
            this.count6.Name = "count6";
            this.count6.Size = new System.Drawing.Size(51, 17);
            this.count6.TabIndex = 5;
            this.count6.Text = "count6";
            // 
            // count5
            // 
            this.count5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.count5.AutoSize = true;
            this.count5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.count5.Location = new System.Drawing.Point(664, 425);
            this.count5.Name = "count5";
            this.count5.Size = new System.Drawing.Size(51, 17);
            this.count5.TabIndex = 4;
            this.count5.Text = "count5";
            // 
            // count3
            // 
            this.count3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.count3.AutoSize = true;
            this.count3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.count3.Location = new System.Drawing.Point(664, 391);
            this.count3.Name = "count3";
            this.count3.Size = new System.Drawing.Size(51, 17);
            this.count3.TabIndex = 3;
            this.count3.Text = "count3";
            // 
            // count2
            // 
            this.count2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.count2.AutoSize = true;
            this.count2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.count2.Location = new System.Drawing.Point(664, 374);
            this.count2.Name = "count2";
            this.count2.Size = new System.Drawing.Size(51, 17);
            this.count2.TabIndex = 2;
            this.count2.Text = "count2";
            // 
            // count1
            // 
            this.count1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.count1.AutoSize = true;
            this.count1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.count1.Location = new System.Drawing.Point(664, 357);
            this.count1.Name = "count1";
            this.count1.Size = new System.Drawing.Size(51, 17);
            this.count1.TabIndex = 1;
            this.count1.Text = "count1";
            // 
            // count0
            // 
            this.count0.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.count0.AutoSize = true;
            this.count0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.count0.Location = new System.Drawing.Point(664, 340);
            this.count0.Name = "count0";
            this.count0.Size = new System.Drawing.Size(51, 17);
            this.count0.TabIndex = 0;
            this.count0.Text = "count0";
            // 
            // btnTrainModel
            // 
            this.btnTrainModel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnTrainModel.AutoSize = true;
            this.btnTrainModel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnTrainModel.BackColor = System.Drawing.SystemColors.Control;
            this.btnTrainModel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTrainModel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTrainModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrainModel.Location = new System.Drawing.Point(416, 292);
            this.btnTrainModel.Name = "btnTrainModel";
            this.btnTrainModel.Size = new System.Drawing.Size(117, 34);
            this.btnTrainModel.TabIndex = 16;
            this.btnTrainModel.Text = "Train Model";
            this.btnTrainModel.UseMnemonic = false;
            this.btnTrainModel.UseVisualStyleBackColor = false;
            this.btnTrainModel.Click += new System.EventHandler(this.btnTrainModel_Click);
            // 
            // btnSaveModel
            // 
            this.btnSaveModel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSaveModel.AutoSize = true;
            this.btnSaveModel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSaveModel.BackColor = System.Drawing.SystemColors.Control;
            this.btnSaveModel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveModel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveModel.Location = new System.Drawing.Point(545, 292);
            this.btnSaveModel.Name = "btnSaveModel";
            this.btnSaveModel.Size = new System.Drawing.Size(116, 34);
            this.btnSaveModel.TabIndex = 17;
            this.btnSaveModel.Text = "Save Model";
            this.btnSaveModel.UseMnemonic = false;
            this.btnSaveModel.UseVisualStyleBackColor = false;
            this.btnSaveModel.Click += new System.EventHandler(this.btnSaveModel_Click);
            // 
            // ctlTrainingSuite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.btnSaveModel);
            this.Controls.Add(this.countNaN);
            this.Controls.Add(this.count9);
            this.Controls.Add(this.btnTrainModel);
            this.Controls.Add(this.count8);
            this.Controls.Add(this.count7);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.count6);
            this.Controls.Add(this.count4);
            this.Controls.Add(this.count5);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnTrainingNumber);
            this.Controls.Add(this.lblTrainAs);
            this.Controls.Add(this.count3);
            this.Controls.Add(this.btnFillGrid);
            this.Controls.Add(this.count2);
            this.Controls.Add(this.btnClearGrid);
            this.Controls.Add(this.count1);
            this.Controls.Add(this.pnlDrawingGrid);
            this.Controls.Add(this.count0);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ctlTrainingSuite";
            this.Size = new System.Drawing.Size(1000, 1000);
            this.cntxTrainingNumbers.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlDrawingGrid;
        private System.Windows.Forms.Button btnClearGrid;
        private System.Windows.Forms.Button btnFillGrid;
        private System.Windows.Forms.Label lblTrainAs;
        private System.Windows.Forms.Button btnTrainingNumber;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblTitle;
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
        private System.Windows.Forms.Button btnTrainModel;
        private System.Windows.Forms.Label countNaN;
        private System.Windows.Forms.Label count9;
        private System.Windows.Forms.Label count8;
        private System.Windows.Forms.Label count7;
        private System.Windows.Forms.Label count4;
        private System.Windows.Forms.Label count6;
        private System.Windows.Forms.Label count5;
        private System.Windows.Forms.Label count3;
        private System.Windows.Forms.Label count2;
        private System.Windows.Forms.Label count1;
        private System.Windows.Forms.Label count0;
        private System.Windows.Forms.Button btnSaveModel;
    }
}
