namespace HandwritingNeuralNetwork
{
    partial class frmMain
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.MainPanel = new System.Windows.Forms.Panel();
            this.mnuNavigation = new System.Windows.Forms.MenuStrip();
            this.analysisPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trainingPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNavigation.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.MainPanel.Location = new System.Drawing.Point(0, 28);
            this.MainPanel.Margin = new System.Windows.Forms.Padding(0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1902, 1005);
            this.MainPanel.TabIndex = 0;
            // 
            // mnuNavigation
            // 
            this.mnuNavigation.BackColor = System.Drawing.Color.LightSkyBlue;
            this.mnuNavigation.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnuNavigation.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.analysisPageToolStripMenuItem,
            this.trainingPageToolStripMenuItem});
            this.mnuNavigation.Location = new System.Drawing.Point(0, 0);
            this.mnuNavigation.Name = "mnuNavigation";
            this.mnuNavigation.Size = new System.Drawing.Size(1902, 28);
            this.mnuNavigation.TabIndex = 1;
            this.mnuNavigation.Text = "menuStrip1";
            // 
            // analysisPageToolStripMenuItem
            // 
            this.analysisPageToolStripMenuItem.Name = "analysisPageToolStripMenuItem";
            this.analysisPageToolStripMenuItem.Size = new System.Drawing.Size(112, 24);
            this.analysisPageToolStripMenuItem.Text = "Analysis Page";
            // 
            // trainingPageToolStripMenuItem
            // 
            this.trainingPageToolStripMenuItem.Name = "trainingPageToolStripMenuItem";
            this.trainingPageToolStripMenuItem.Size = new System.Drawing.Size(112, 24);
            this.trainingPageToolStripMenuItem.Text = "Training Page";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.mnuNavigation);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuNavigation;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hand Writing Neural Network";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.mnuNavigation.ResumeLayout(false);
            this.mnuNavigation.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.MenuStrip mnuNavigation;
        private System.Windows.Forms.ToolStripMenuItem analysisPageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trainingPageToolStripMenuItem;
    }
}

