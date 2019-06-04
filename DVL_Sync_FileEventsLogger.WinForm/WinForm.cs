using DVL_Sync_FileEventsLogger.Abstractions;
using DVL_Sync_FileEventsLogger.Extensions;
using DVL_Sync_FileEventsLogger.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DVL_Sync_FileEventsLogger.WinForm
{
    public partial class WinForm : Form
    {
        private IEnumerable<IFolderWatcher> watchers;
        private bool exitClicked = false;
        private FoldersWatcherConfig folderWatcherConfig;

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
            exitClicked = true;
            this.Close();
        }

        private void ButtonBrowseFolderConfigsPath_Click(object sender, EventArgs e)
        {
            openFileDialogFolderConfigsPath.Filter = "Json files (*.json)|*.json";
            if (openFileDialogFolderConfigsPath.ShowDialog() == DialogResult.OK)
            {
                textBoxFoldersConfigsPath.Text = openFileDialogFolderConfigsPath.FileName;
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
            if (!exitClicked)
            {
                e.Cancel = true;
                this.ShowInTaskbar = false;
                this.WindowState = FormWindowState.Minimized;
                this.Visible = false;
                customNotifyIcon.Visible = true;
            }
        }
    }
}
