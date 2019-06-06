﻿using DVL_Sync_FileEventsLogger.Models;
using DVL_Sync_FileEventsLogger.WinForm.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace DVL_Sync_FileEventsLogger.WinForm
{
    //public class FilteredFile
    //{
    //    public string ColumnName { get; set; }
    //}

    public partial class FolderConfigDialogForm : Form
    {
        public FolderConfig folderConfig;

        public FolderConfigDialogForm()
        {
            InitializeComponent();
        }

        private void ButtonBrowseFolderPath_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialogFolderPath.ShowDialog() == DialogResult.OK)
            {
                this.textBoxFolderPath.Text = this.folderBrowserDialogFolderPath.SelectedPath;
            }
        }

        private void ButtonAddFilteredFile_Click(object sender, EventArgs e)
        {
            if (this.openFileDialogFilteredFiles.ShowDialog() == DialogResult.OK)
            {
                this.dataGridViewFilteredFiles.Rows.Add(new FilteredFileViewModel
                    {FilePath = this.openFileDialogFilteredFiles.FileName});
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.dataGridViewFilteredFiles.SelectedRows)
                this.dataGridViewFilteredFiles.Rows.RemoveAt(item.Index);
        }

        private void ButtonClose_Click(object sender, EventArgs e) => Close();

        private void ButtonSaveConfiguration_Click(object sender, EventArgs e)
        {
            if (this.folderConfig == null)
                this.folderConfig = new FolderConfig();

            this.folderConfig.FolderPath = this.textBoxFolderPath.Text;
            this.folderConfig.FilteredFiles = GetFilteredFilesFromGrid().Select(file => file.FilePath).ToList();
            this.folderConfig.IncludeSubDirectories = this.checkBoxIncludeSubdirectories.Checked;
            this.folderConfig.WatchHiddenFiles = this.checkBoxWatchHiddenFiles.Checked;
            Close();
        }

        private IEnumerable<FilteredFileViewModel> GetFilteredFilesFromGrid()
        {
            foreach (DataGridViewRow row in this.dataGridViewFilteredFiles.Rows)
            {
                var k = (FilteredFileViewModel) row.DataBoundItem;
                yield return k;
            }
        }
    }
}