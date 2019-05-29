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

        private void ButtonBrowseFolderConfigsPath_Click(object sender, EventArgs e)
        {
            if (openFileDialogFolderConfigsPath.ShowDialog() == DialogResult.OK)
            {
                //openFileDialogFolderConfigsPath.
            }
        }

        private void DsafdadfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            this.ShowInTaskbar = true;
            this.WindowState = FormWindowState.Normal;
        }

        private void WinForm_Load(object sender, EventArgs e)
        {

        }

        private void WinForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.CloseReason
            e.Cancel = true;
            this.ShowInTaskbar = false;
            this.WindowState = FormWindowState.Minimized;
            this.Visible = false;
            customNotifyIcon.Visible = true;
        }
    }
}
