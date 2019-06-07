﻿using DVL_Sync_FileEventsLogger.Abstractions;
using DVL_Sync_FileEventsLogger.Extensions;
using DVL_Sync_FileEventsLogger.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DVL_Sync_FileEventsLogger.WinForm
{
    public partial class FolderWatcherConfigurationForm : Form
    {
        private IEnumerable<IFolderWatcher> watchers;
        private bool exitClicked = false;
        private FoldersWatcherConfig folderWatchersConfig;
        private HashSet<LoggerType> loggerTypesHashSet;
        private readonly string configName = "config.json";

        private List<FolderConfig> folderConfigs;
        private readonly string applicationName = "DVL_Sync_FileEventsLogger";

        public FolderWatcherConfigurationForm()
        {
            InitializeComponent();

            SetFolderWatcherConfig($"{Environment.CurrentDirectory}/{this.configName}");
            SetWatchers();
            this.ShowInTaskbar = false;
            this.WindowState = FormWindowState.Minimized;
            this.customNotifyIcon.Visible = true;
            this.tabControl1.TabPages.Remove(this.tabPageFolderConfigs);
            //customNotifyIcon.ShowBalloonTip(500);
            //this.Hide();
        }

        #region Events

        private void WinForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.exitClicked)
            {
                e.Cancel = true;
                HideForm();
            }
        }

        private void CustomNotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                this.customNotifyIcon.ContextMenuStrip.Show();
            else if (e.Button == MouseButtons.Left)
                OpenForm();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.exitClicked = true;
            Close();
        }

        private void ButtonBrowseFolderConfigsPath_Click(object sender, EventArgs e)
        {
            this.openFileDialogFolderConfigsPath.Filter = "Json files (*.json)|*.json";
            if (this.openFileDialogFolderConfigsPath.ShowDialog() == DialogResult.OK)
            {
                this.textBoxFoldersConfigsPath.Text = this.openFileDialogFolderConfigsPath.FileName;
            }
        }

        private void WinForm_Load(object sender, EventArgs e)
        {

        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e) => OpenForm();

        private void CheckBoxTextFile_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxTextFile.Checked)
                this.loggerTypesHashSet.Add(LoggerType.TextFile);
            else this.loggerTypesHashSet.Remove(LoggerType.TextFile);
        }

        private void CheckBoxConsole_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxConsole.Checked)
                this.loggerTypesHashSet.Add(LoggerType.Console);
            else this.loggerTypesHashSet.Remove(LoggerType.Console);
        }

        private void CheckBoxJsonFile_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxJsonFile.Checked)
                this.loggerTypesHashSet.Add(LoggerType.JsonFile);
            else this.loggerTypesHashSet.Remove(LoggerType.JsonFile);
        }

        private void CheckBoxWindows10Notification_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxWindows10Notification.Checked)
            {
                this.loggerTypesHashSet.Add(LoggerType.Windows10Notification);
                ShowAppID();
            }
            else
            {
                this.loggerTypesHashSet.Remove(LoggerType.Windows10Notification);
                HideAppID();
            }
        }

        private void ButtonSaveConfiguration_Click(object sender, EventArgs e)
        {
            if (!ValideFolderWatcherConfig())
                return;

            this.folderWatchersConfig.IFolderWatcher = this.textBoxIFolderWatcher.Text;
            this.folderWatchersConfig.LoggerTypes = this.loggerTypesHashSet.ToArray();
            this.folderWatchersConfig.FoldersConfigsPath = this.textBoxFoldersConfigsPath.Text;
            this.folderWatchersConfig.IFolderEventsHandler = this.textBoxIFolderEventsHandler.Text;
            this.folderWatchersConfig.IOperationEventFactory = this.textBoxIOperationEventFactory.Text;
            if (this.checkBoxWindows10Notification.Checked)
                this.folderWatchersConfig.AppID = this.textBoxAppID.Text;
            else this.folderWatchersConfig.AppID = null;

            //Saving Part
            SaveFolderConfigsIfRequired();
            SaveFolderWatcherConfigFile($"{Environment.CurrentDirectory}/{this.configName}");

            ////Set Watchers
            //SetFolderWatcherConfig($"{Environment.CurrentDirectory}/{this.configName}");
            //SetWatchers();

            //Close();
            Application.Restart();
            Environment.Exit(0);
        }

        private void ButtonClose_Click(object sender, EventArgs e) => Close();

        private void ButtonAddFolderConfig_Click(object sender, EventArgs e)
        {
            var form = new FolderConfigDialogForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                AddFolderConfigToForm(form.folderConfig);
            }
        }

        private void ButtonRemoveFolderConfig_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.dataGridViewFolderConfigs.SelectedRows)
            {
                int index = item.Index;
                if (index >= 0)
                {
                    this.dataGridViewFolderConfigs.Rows.RemoveAt(index);
                    this.folderConfigs.RemoveAt(index);
                }
            }
        }

        private void CheckBoxAddManuallyConfigs_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxAddManuallyConfigs.Checked)
            {
                this.tabControl1.TabPages.Add(this.tabPageFolderConfigs);
                this.textBoxFoldersConfigsPath.Enabled = false;
                this.buttonBrowseFolderConfigsPath.Enabled = false;
            }
            else
            {
                this.tabControl1.TabPages.Remove(this.tabPageFolderConfigs);
                this.textBoxFoldersConfigsPath.Enabled = true;
                this.buttonBrowseFolderConfigsPath.Enabled = true;
            }
        }

        #endregion

        #region UI Methods

        private void HideForm()
        {
            this.ShowInTaskbar = false;
            this.WindowState = FormWindowState.Minimized;
            this.Visible = false;
            this.customNotifyIcon.Visible = true;
        }

        private void OpenForm()
        {
            SetFolderWatcherConfig($"{Environment.CurrentDirectory}/{this.configName}");

            this.folderConfigs = this.folderWatchersConfig.FoldersConfigsPath.GetFolderConfigs().ToList();
            foreach (var folderConfig in this.folderConfigs)
                AddFolderConfigToForm(folderConfig);

            SetWatchers();
            ShowForm();
        }

        private void ShowForm()
        {
            this.Visible = true;
            this.ShowInTaskbar = true;
            this.WindowState = FormWindowState.Normal;
        }

        private void ShowAppID()
        {
            this.textBoxAppID.Text = this.folderWatchersConfig.AppID;
            this.labelAppID.Visible = true;
            this.textBoxAppID.Visible = true;
        }

        private void HideAppID()
        {
            this.textBoxAppID.Text = null;
            this.labelAppID.Visible = false;
            this.textBoxAppID.Visible = false;
        }

        private void SetLoggerTypes()
        {
            if (this.loggerTypesHashSet == null || this.loggerTypesHashSet.Count == 0)
                this.loggerTypesHashSet = new HashSet<LoggerType>();

            this.loggerTypesHashSet.Clear();
            this.loggerTypesHashSet.UnionWith(this.folderWatchersConfig.LoggerTypes);

            if (this.loggerTypesHashSet.Contains(LoggerType.Windows10Notification))
            {
                this.textBoxAppID.Text = this.folderWatchersConfig.AppID;
                this.labelAppID.Visible = true;
                this.textBoxAppID.Visible = true;
            }
            else
            {
                this.textBoxAppID.Text = null;
                this.labelAppID.Visible = false;
                this.textBoxAppID.Visible = false;
            }

            //ResetLoggerTypeCheckboxes();

            if (this.loggerTypesHashSet.Contains(LoggerType.TextFile))
                this.checkBoxTextFile.Checked = true;
            else this.checkBoxTextFile.Checked = false;


            if (this.loggerTypesHashSet.Contains(LoggerType.JsonFile))
                this.checkBoxJsonFile.Checked = true;
            else this.checkBoxJsonFile.Checked = false;


            if (this.loggerTypesHashSet.Contains(LoggerType.Console))
                this.checkBoxConsole.Checked = true;
            else this.checkBoxConsole.Checked = false;


            if (this.loggerTypesHashSet.Contains(LoggerType.Windows10Notification))
                this.checkBoxWindows10Notification.Checked = true;
            else this.checkBoxWindows10Notification.Checked = false;
        }

        private void AddFolderConfigToForm(FolderConfig folderConfig)
        {
            var index = this.dataGridViewFolderConfigs.Rows.Add();
            this.dataGridViewFolderConfigs.Rows[index].Cells["ColumnFolderPath"].Value =
                folderConfig.FolderPath;
            this.dataGridViewFolderConfigs.Rows[index].Cells["ColumnIncludeSubdirectories"].Value =
                folderConfig.IncludeSubDirectories;
            this.dataGridViewFolderConfigs.Rows[index].Cells["ColumnWatchHiddenFiles"].Value =
                folderConfig.WatchHiddenFiles;
            this.dataGridViewFolderConfigs.Rows[index].Cells["ColumnFilteredFiles"].Value =
                string.Join(", ", folderConfig.FilteredFiles);
        }

        #endregion

        ///// <summary>
        ///// Deprecated 
        ///// </summary>
        //private void ResetLoggerTypeCheckboxes()
        //{
        //    this.checkBoxTextFile.Checked = false;
        //    this.checkBoxJsonFile.Checked = false;
        //    this.checkBoxConsole.Checked = false;
        //    this.checkBoxWindows10Notification.Checked = false;
        //}

        #region Functional Methods

        private void SaveFolderWatcherConfigFile(string path)
        {
            string jsonString = JsonConvert.SerializeObject(this.folderWatchersConfig);
            using (var stream = new StreamWriter(path, false))
            {
                stream.Write(jsonString);
            }
        }

        private void SaveFoldersConfigsFile(string path)
        {
            this.folderWatchersConfig.FoldersConfigsPath = path;

            string jsonString = JsonConvert.SerializeObject(this.folderConfigs);
            using (var stream = new StreamWriter(path, false))
            {
                stream.Write(jsonString);
            }
        }

        private void SetWatchers()
        {
            if (this.watchers != null)
                this.watchers.Dispose();
            if (this.folderWatchersConfig == null)
                return;
            if (this.watchers != null)
                this.watchers = null;
            this.watchers = this.folderWatchersConfig.GetFolderWatchers();
            this.watchers.StartWatching();
        }

        private void SetFolderWatcherConfig(string path)
        {
            this.folderWatchersConfig = path.GetFoldersWatcherConfig();

            //Setting In UI
            this.textBoxIFolderWatcher.Text = this.folderWatchersConfig.IFolderWatcher;
            this.textBoxFoldersConfigsPath.Text = this.folderWatchersConfig.FoldersConfigsPath;
            this.textBoxIFolderEventsHandler.Text = this.folderWatchersConfig.IFolderEventsHandler;
            this.textBoxIOperationEventFactory.Text = this.folderWatchersConfig.IOperationEventFactory;

            SetLoggerTypes();

            //SaveFolderWatcherConfigFile($"{Environment.CurrentDirectory}/{this.configName}");
        }

        private bool ValideFolderWatcherConfig()
        {
            if (!this.checkBoxAddManuallyConfigs.Checked && string.IsNullOrEmpty(this.textBoxFoldersConfigsPath.Text))
                return false;

            return true;
        }

        private void SaveFolderConfigsIfRequired()
        {
            if (!this.checkBoxAddManuallyConfigs.Checked)
                return;

            SaveFoldersConfigsFile($"{DriveInfo.GetDrives()[0].Name}\\{this.applicationName}\\FoldersConfigs.json");
        }

        #endregion

    }
}
