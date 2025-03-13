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
            this.navAnalysisPage = new System.Windows.Forms.ToolStripMenuItem();
            this.navTrainingPage = new System.Windows.Forms.ToolStripMenuItem();
            this.navLogout = new System.Windows.Forms.ToolStripMenuItem();
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
            this.mnuNavigation.Enabled = false;
            this.mnuNavigation.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnuNavigation.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.navLogout,
            this.navAnalysisPage,
            this.navTrainingPage});
            this.mnuNavigation.Location = new System.Drawing.Point(0, 0);
            this.mnuNavigation.Name = "mnuNavigation";
            this.mnuNavigation.Size = new System.Drawing.Size(1902, 30);
            this.mnuNavigation.TabIndex = 1;
            this.mnuNavigation.Text = "menuStrip1";
            // 
            // navAnalysisPage
            // 
            this.navAnalysisPage.Name = "navAnalysisPage";
            this.navAnalysisPage.Size = new System.Drawing.Size(112, 26);
            this.navAnalysisPage.Text = "Analysis Page";
            this.navAnalysisPage.Visible = false;
            this.navAnalysisPage.Click += new System.EventHandler(this.navAnalysisPage_Click);
            // 
            // navTrainingPage
            // 
            this.navTrainingPage.Name = "navTrainingPage";
            this.navTrainingPage.Size = new System.Drawing.Size(112, 26);
            this.navTrainingPage.Text = "Training Page";
            this.navTrainingPage.Visible = false;
            this.navTrainingPage.Click += new System.EventHandler(this.navTrainingPage_Click);
            // 
            // navLogout
            // 
            this.navLogout.Name = "navLogout";
            this.navLogout.Size = new System.Drawing.Size(70, 26);
            this.navLogout.Text = "Logout";
            this.navLogout.Visible = false;
            this.navLogout.Click += new System.EventHandler(this.navLogOut_Click);
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
            this.mnuNavigation.ResumeLayout(false);
            this.mnuNavigation.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.MenuStrip mnuNavigation;
        private System.Windows.Forms.ToolStripMenuItem navAnalysisPage;
        private System.Windows.Forms.ToolStripMenuItem navTrainingPage;
        private System.Windows.Forms.ToolStripMenuItem navLogout;
    }
}

