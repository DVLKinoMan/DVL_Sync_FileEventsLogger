using DVL_Sync_FileEventsLogger.Abstractions;
using DVL_Sync_FileEventsLogger.Extensions;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DVL_Sync_FileEventsLogger.WinForm
{
    public partial class WinForm : Form
    {
        private IEnumerable<IFolderWatcher> watchers;

        public WinForm()
        {
            InitializeComponent();
            SetWatchers();
            this.ShowInTaskbar = false;
            this.WindowState = FormWindowState.Minimized;
            customNotifyIcon.Visible = true;
            //customNotifyIcon.ShowBalloonTip(500);
            //this.Hide();
        }

        private void SetWatchers()
        {
            string configName = "config.json";

            watchers =
                $"{Environment.CurrentDirectory}/{configName}".GetFoldersWatcherConfig().GetFolderWatchers();
            watchers.StartWatching();
        }

        private void CustomNotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                customNotifyIcon.ContextMenuStrip.Show();
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
