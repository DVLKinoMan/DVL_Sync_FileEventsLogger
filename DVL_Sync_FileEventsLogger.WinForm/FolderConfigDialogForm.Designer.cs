namespace DVL_Sync_FileEventsLogger.WinForm
{
    partial class FolderConfigDialogForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FolderConfigDialogForm));
            this.folderBrowserDialogFolderPath = new System.Windows.Forms.FolderBrowserDialog();
            this.labelFolderPath = new System.Windows.Forms.Label();
            this.textBoxFolderPath = new System.Windows.Forms.TextBox();
            this.buttonBrowseFolderPath = new System.Windows.Forms.Button();
            this.checkBoxIncludeSubdirectories = new System.Windows.Forms.CheckBox();
            this.checkBoxWatchHiddenFiles = new System.Windows.Forms.CheckBox();
            this.dataGridViewFilteredFiles = new System.Windows.Forms.DataGridView();
            this.buttonAddFilteredFile = new System.Windows.Forms.Button();
            this.openFileDialogFilteredFiles = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonSaveConfiguration = new System.Windows.Forms.Button();
            this.ColumnFilePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.filteredFileViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFilteredFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filteredFileViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // labelFolderPath
            // 
            this.labelFolderPath.AutoSize = true;
            this.labelFolderPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFolderPath.Location = new System.Drawing.Point(30, 33);
            this.labelFolderPath.Name = "labelFolderPath";
            this.labelFolderPath.Size = new System.Drawing.Size(91, 20);
            this.labelFolderPath.TabIndex = 0;
            this.labelFolderPath.Text = "FolderPath:";
            // 
            // textBoxFolderPath
            // 
            this.textBoxFolderPath.Location = new System.Drawing.Point(241, 33);
            this.textBoxFolderPath.Name = "textBoxFolderPath";
            this.textBoxFolderPath.Size = new System.Drawing.Size(223, 20);
            this.textBoxFolderPath.TabIndex = 1;
            // 
            // buttonBrowseFolderPath
            // 
            this.buttonBrowseFolderPath.Location = new System.Drawing.Point(470, 31);
            this.buttonBrowseFolderPath.Name = "buttonBrowseFolderPath";
            this.buttonBrowseFolderPath.Size = new System.Drawing.Size(71, 23);
            this.buttonBrowseFolderPath.TabIndex = 2;
            this.buttonBrowseFolderPath.Text = "browse";
            this.buttonBrowseFolderPath.UseVisualStyleBackColor = true;
            this.buttonBrowseFolderPath.Click += new System.EventHandler(this.ButtonBrowseFolderPath_Click);
            // 
            // checkBoxIncludeSubdirectories
            // 
            this.checkBoxIncludeSubdirectories.AutoSize = true;
            this.checkBoxIncludeSubdirectories.Checked = true;
            this.checkBoxIncludeSubdirectories.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxIncludeSubdirectories.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxIncludeSubdirectories.Location = new System.Drawing.Point(34, 90);
            this.checkBoxIncludeSubdirectories.Name = "checkBoxIncludeSubdirectories";
            this.checkBoxIncludeSubdirectories.Size = new System.Drawing.Size(186, 24);
            this.checkBoxIncludeSubdirectories.TabIndex = 4;
            this.checkBoxIncludeSubdirectories.Text = "Include Subdirectories";
            this.checkBoxIncludeSubdirectories.UseVisualStyleBackColor = true;
            // 
            // checkBoxWatchHiddenFiles
            // 
            this.checkBoxWatchHiddenFiles.AutoSize = true;
            this.checkBoxWatchHiddenFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxWatchHiddenFiles.Location = new System.Drawing.Point(34, 142);
            this.checkBoxWatchHiddenFiles.Name = "checkBoxWatchHiddenFiles";
            this.checkBoxWatchHiddenFiles.Size = new System.Drawing.Size(166, 24);
            this.checkBoxWatchHiddenFiles.TabIndex = 5;
            this.checkBoxWatchHiddenFiles.Text = "Watch Hidden Files";
            this.checkBoxWatchHiddenFiles.UseVisualStyleBackColor = true;
            // 
            // dataGridViewFilteredFiles
            // 
            this.dataGridViewFilteredFiles.AllowUserToAddRows = false;
            this.dataGridViewFilteredFiles.AllowUserToDeleteRows = false;
            this.dataGridViewFilteredFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFilteredFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnFilePath});
            this.dataGridViewFilteredFiles.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewFilteredFiles.Location = new System.Drawing.Point(34, 193);
            this.dataGridViewFilteredFiles.Name = "dataGridViewFilteredFiles";
            this.dataGridViewFilteredFiles.Size = new System.Drawing.Size(641, 207);
            this.dataGridViewFilteredFiles.TabIndex = 6;
            // 
            // buttonAddFilteredFile
            // 
            this.buttonAddFilteredFile.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.buttonAddFilteredFile.Location = new System.Drawing.Point(550, 169);
            this.buttonAddFilteredFile.Name = "buttonAddFilteredFile";
            this.buttonAddFilteredFile.Size = new System.Drawing.Size(125, 23);
            this.buttonAddFilteredFile.TabIndex = 7;
            this.buttonAddFilteredFile.Text = "Add Filtered File";
            this.buttonAddFilteredFile.UseVisualStyleBackColor = true;
            this.buttonAddFilteredFile.Click += new System.EventHandler(this.ButtonAddFilteredFile_Click);
            // 
            // openFileDialogFilteredFiles
            // 
            this.openFileDialogFilteredFiles.FileName = "openFileDialogFilteredFiles";
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.button1.Location = new System.Drawing.Point(416, 169);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Remove Filtered Files";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClose.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonClose.Location = new System.Drawing.Point(202, 418);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(91, 29);
            this.buttonClose.TabIndex = 21;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // buttonSaveConfiguration
            // 
            this.buttonSaveConfiguration.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonSaveConfiguration.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSaveConfiguration.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.buttonSaveConfiguration.Location = new System.Drawing.Point(405, 418);
            this.buttonSaveConfiguration.Name = "buttonSaveConfiguration";
            this.buttonSaveConfiguration.Size = new System.Drawing.Size(91, 29);
            this.buttonSaveConfiguration.TabIndex = 20;
            this.buttonSaveConfiguration.Text = "Save";
            this.buttonSaveConfiguration.UseVisualStyleBackColor = true;
            this.buttonSaveConfiguration.Click += new System.EventHandler(this.ButtonSaveConfiguration_Click);
            // 
            // ColumnFilePath
            // 
            this.ColumnFilePath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnFilePath.HeaderText = "File Path";
            this.ColumnFilePath.Name = "ColumnFilePath";
            // 
            // filteredFileViewModelBindingSource
            // 
            this.filteredFileViewModelBindingSource.DataSource = typeof(DVL_Sync_FileEventsLogger.WinForm.Models.FilteredFileViewModel);
            // 
            // FolderConfigDialogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 459);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonSaveConfiguration);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonAddFilteredFile);
            this.Controls.Add(this.dataGridViewFilteredFiles);
            this.Controls.Add(this.checkBoxWatchHiddenFiles);
            this.Controls.Add(this.checkBoxIncludeSubdirectories);
            this.Controls.Add(this.buttonBrowseFolderPath);
            this.Controls.Add(this.textBoxFolderPath);
            this.Controls.Add(this.labelFolderPath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FolderConfigDialogForm";
            this.Text = "Folder Config";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFilteredFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filteredFileViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogFolderPath;
        private System.Windows.Forms.Label labelFolderPath;
        private System.Windows.Forms.TextBox textBoxFolderPath;
        private System.Windows.Forms.Button buttonBrowseFolderPath;
        private System.Windows.Forms.CheckBox checkBoxIncludeSubdirectories;
        private System.Windows.Forms.CheckBox checkBoxWatchHiddenFiles;
        private System.Windows.Forms.DataGridView dataGridViewFilteredFiles;
        private System.Windows.Forms.Button buttonAddFilteredFile;
        private System.Windows.Forms.OpenFileDialog openFileDialogFilteredFiles;
        private System.Windows.Forms.BindingSource filteredFileViewModelBindingSource;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonSaveConfiguration;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFilePath;
    }
}