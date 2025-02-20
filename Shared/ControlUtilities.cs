using System.Windows.Forms;

namespace HandwritingNeuralNetwork.Shared
{
    public static class ControlUtilities
    {
        public static void PanelLoad(Panel pnl, Control cntr)
        {
            pnl.Controls.Clear();
            pnl.SuspendLayout();
            if (cntr != null)
            {
                pnl.Controls.Add(cntr);
                cntr.Dock = DockStyle.Fill;
            }
            pnl.Enabled = true;
            pnl.Visible = true;
            pnl.ResumeLayout();
            pnl.Refresh();
        }
    }
}
