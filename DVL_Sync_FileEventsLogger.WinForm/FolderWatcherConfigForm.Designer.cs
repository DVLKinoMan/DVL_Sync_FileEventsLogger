namespace DVL_Sync_FileEventsLogger.WinForm
{
    partial class FolderWatcherConfigurationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FolderWatcherConfigurationForm));
            this.customNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.customContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelIFolderWatcher = new System.Windows.Forms.Label();
            this.textBoxIFolderWatcher = new System.Windows.Forms.TextBox();
            this.textBoxFoldersConfigsPath = new System.Windows.Forms.TextBox();
            this.labelFoldersConfigsPath = new System.Windows.Forms.Label();
            this.textBoxIFolderEventsHandler = new System.Windows.Forms.TextBox();
            this.labelIFolderEventsHandler = new System.Windows.Forms.Label();
            this.textBoxIOperationEventFactory = new System.Windows.Forms.TextBox();
            this.labelIOperationEventFactory = new System.Windows.Forms.Label();
            this.labelLoggerTypes = new System.Windows.Forms.Label();
            this.buttonBrowseFolderConfigsPath = new System.Windows.Forms.Button();
            this.openFileDialogFolderConfigsPath = new System.Windows.Forms.OpenFileDialog();
            this.checkBoxTextFile = new System.Windows.Forms.CheckBox();
            this.checkBoxConsole = new System.Windows.Forms.CheckBox();
            this.checkBoxJsonFile = new System.Windows.Forms.CheckBox();
            this.checkBoxWindows10Notification = new System.Windows.Forms.CheckBox();
            this.buttonSaveConfiguration = new System.Windows.Forms.Button();
            this.textBoxAppID = new System.Windows.Forms.TextBox();
            this.labelAppID = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridViewFolderConfigs = new System.Windows.Forms.DataGridView();
            this.ColumnFolderPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnIncludeSubDirectories = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnWatchHiddenFiles = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.buttonAddFolderConfig = new System.Windows.Forms.Button();
            this.customContextMenu.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFolderConfigs)).BeginInit();
            this.SuspendLayout();
            // 
            // customNotifyIcon
            // 
            this.customNotifyIcon.ContextMenuStrip = this.customContextMenu;
            this.customNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("customNotifyIcon.Icon")));
            this.customNotifyIcon.Text = "DVL_Sync_FileEventsLogger";
            this.customNotifyIcon.Visible = true;
            this.customNotifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CustomNotifyIcon_MouseClick);
            // 
            // customContextMenu
            // 
            this.customContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.customContextMenu.Name = "customContextMenu";
            this.customContextMenu.Size = new System.Drawing.Size(105, 48);
            // 
            // OpenToolStripMenuItem
            // 
            this.OpenToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            this.OpenToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.OpenToolStripMenuItem.Text = "Open";
            this.OpenToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exitToolStripMenuItem.Image")));
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // labelIFolderWatcher
            // 
            this.labelIFolderWatcher.AutoSize = true;
            this.labelIFolderWatcher.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIFolderWatcher.Location = new System.Drawing.Point(6, 10);
            this.labelIFolderWatcher.Name = "labelIFolderWatcher";
            this.labelIFolderWatcher.Size = new System.Drawing.Size(123, 20);
            this.labelIFolderWatcher.TabIndex = 1;
            this.labelIFolderWatcher.Text = "IFolderWatcher:";
            // 
            // textBoxIFolderWatcher
            // 
            this.textBoxIFolderWatcher.Location = new System.Drawing.Point(189, 10);
            this.textBoxIFolderWatcher.Name = "textBoxIFolderWatcher";
            this.textBoxIFolderWatcher.Size = new System.Drawing.Size(190, 20);
            this.textBoxIFolderWatcher.TabIndex = 2;
            // 
            // textBoxFoldersConfigsPath
            // 
            this.textBoxFoldersConfigsPath.Location = new System.Drawing.Point(189, 53);
            this.textBoxFoldersConfigsPath.Name = "textBoxFoldersConfigsPath";
            this.textBoxFoldersConfigsPath.Size = new System.Drawing.Size(190, 20);
            this.textBoxFoldersConfigsPath.TabIndex = 4;
            // 
            // labelFoldersConfigsPath
            // 
            this.labelFoldersConfigsPath.AutoSize = true;
            this.labelFoldersConfigsPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFoldersConfigsPath.Location = new System.Drawing.Point(6, 53);
            this.labelFoldersConfigsPath.Name = "labelFoldersConfigsPath";
            this.labelFoldersConfigsPath.Size = new System.Drawing.Size(153, 20);
            this.labelFoldersConfigsPath.TabIndex = 3;
            this.labelFoldersConfigsPath.Text = "FoldersConfigsPath:";
            // 
            // textBoxIFolderEventsHandler
            // 
            this.textBoxIFolderEventsHandler.Location = new System.Drawing.Point(189, 100);
            this.textBoxIFolderEventsHandler.Name = "textBoxIFolderEventsHandler";
            this.textBoxIFolderEventsHandler.Size = new System.Drawing.Size(190, 20);
            this.textBoxIFolderEventsHandler.TabIndex = 6;
            // 
            // labelIFolderEventsHandler
            // 
            this.labelIFolderEventsHandler.AutoSize = true;
            this.labelIFolderEventsHandler.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIFolderEventsHandler.Location = new System.Drawing.Point(6, 100);
            this.labelIFolderEventsHandler.Name = "labelIFolderEventsHandler";
            this.labelIFolderEventsHandler.Size = new System.Drawing.Size(168, 20);
            this.labelIFolderEventsHandler.TabIndex = 5;
            this.labelIFolderEventsHandler.Text = "IFolderEventsHandler:";
            // 
            // textBoxIOperationEventFactory
            // 
            this.textBoxIOperationEventFactory.Location = new System.Drawing.Point(189, 147);
            this.textBoxIOperationEventFactory.Name = "textBoxIOperationEventFactory";
            this.textBoxIOperationEventFactory.Size = new System.Drawing.Size(190, 20);
            this.textBoxIOperationEventFactory.TabIndex = 8;
            // 
            // labelIOperationEventFactory
            // 
            this.labelIOperationEventFactory.AutoSize = true;
            this.labelIOperationEventFactory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIOperationEventFactory.Location = new System.Drawing.Point(6, 147);
            this.labelIOperationEventFactory.Name = "labelIOperationEventFactory";
            this.labelIOperationEventFactory.Size = new System.Drawing.Size(182, 20);
            this.labelIOperationEventFactory.TabIndex = 7;
            this.labelIOperationEventFactory.Text = "IOperationEventFactory:";
            // 
            // labelLoggerTypes
            // 
            this.labelLoggerTypes.AutoSize = true;
            this.labelLoggerTypes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLoggerTypes.Location = new System.Drawing.Point(6, 193);
            this.labelLoggerTypes.Name = "labelLoggerTypes";
            this.labelLoggerTypes.Size = new System.Drawing.Size(105, 20);
            this.labelLoggerTypes.TabIndex = 9;
            this.labelLoggerTypes.Text = "LoggerTypes:";
            // 
            // buttonBrowseFolderConfigsPath
            // 
            this.buttonBrowseFolderConfigsPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBrowseFolderConfigsPath.Location = new System.Drawing.Point(385, 53);
            this.buttonBrowseFolderConfigsPath.Name = "buttonBrowseFolderConfigsPath";
            this.buttonBrowseFolderConfigsPath.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowseFolderConfigsPath.TabIndex = 11;
            this.buttonBrowseFolderConfigsPath.Text = "Browse";
            this.buttonBrowseFolderConfigsPath.UseVisualStyleBackColor = true;
            this.buttonBrowseFolderConfigsPath.Click += new System.EventHandler(this.ButtonBrowseFolderConfigsPath_Click);
            // 
            // openFileDialogFolderConfigsPath
            // 
            this.openFileDialogFolderConfigsPath.FileName = "openFileDialogFolderConfigsPath";
            // 
            // checkBoxTextFile
            // 
            this.checkBoxTextFile.AutoSize = true;
            this.checkBoxTextFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxTextFile.Location = new System.Drawing.Point(185, 195);
            this.checkBoxTextFile.Name = "checkBoxTextFile";
            this.checkBoxTextFile.Size = new System.Drawing.Size(83, 24);
            this.checkBoxTextFile.TabIndex = 12;
            this.checkBoxTextFile.Text = "TextFile";
            this.checkBoxTextFile.UseVisualStyleBackColor = true;
            this.checkBoxTextFile.CheckedChanged += new System.EventHandler(this.CheckBoxTextFile_CheckedChanged);
            // 
            // checkBoxConsole
            // 
            this.checkBoxConsole.AutoSize = true;
            this.checkBoxConsole.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxConsole.Location = new System.Drawing.Point(289, 195);
            this.checkBoxConsole.Name = "checkBoxConsole";
            this.checkBoxConsole.Size = new System.Drawing.Size(86, 24);
            this.checkBoxConsole.TabIndex = 13;
            this.checkBoxConsole.Text = "Console";
            this.checkBoxConsole.UseVisualStyleBackColor = true;
            this.checkBoxConsole.CheckedChanged += new System.EventHandler(this.CheckBoxConsole_CheckedChanged);
            // 
            // checkBoxJsonFile
            // 
            this.checkBoxJsonFile.AutoSize = true;
            this.checkBoxJsonFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxJsonFile.Location = new System.Drawing.Point(398, 195);
            this.checkBoxJsonFile.Name = "checkBoxJsonFile";
            this.checkBoxJsonFile.Size = new System.Drawing.Size(87, 24);
            this.checkBoxJsonFile.TabIndex = 14;
            this.checkBoxJsonFile.Text = "JsonFile";
            this.checkBoxJsonFile.UseVisualStyleBackColor = true;
            this.checkBoxJsonFile.CheckedChanged += new System.EventHandler(this.CheckBoxJsonFile_CheckedChanged);
            // 
            // checkBoxWindows10Notification
            // 
            this.checkBoxWindows10Notification.AutoSize = true;
            this.checkBoxWindows10Notification.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxWindows10Notification.Location = new System.Drawing.Point(491, 195);
            this.checkBoxWindows10Notification.Name = "checkBoxWindows10Notification";
            this.checkBoxWindows10Notification.Size = new System.Drawing.Size(189, 24);
            this.checkBoxWindows10Notification.TabIndex = 15;
            this.checkBoxWindows10Notification.Text = "Windows10Notification";
            this.checkBoxWindows10Notification.UseVisualStyleBackColor = true;
            this.checkBoxWindows10Notification.CheckedChanged += new System.EventHandler(this.CheckBoxWindows10Notification_CheckedChanged);
            // 
            // buttonSaveConfiguration
            // 
            this.buttonSaveConfiguration.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSaveConfiguration.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.buttonSaveConfiguration.Location = new System.Drawing.Point(381, 315);
            this.buttonSaveConfiguration.Name = "buttonSaveConfiguration";
            this.buttonSaveConfiguration.Size = new System.Drawing.Size(91, 29);
            this.buttonSaveConfiguration.TabIndex = 16;
            this.buttonSaveConfiguration.Text = "Save";
            this.buttonSaveConfiguration.UseVisualStyleBackColor = true;
            this.buttonSaveConfiguration.Click += new System.EventHandler(this.ButtonSaveConfiguration_Click);
            // 
            // textBoxAppID
            // 
            this.textBoxAppID.Location = new System.Drawing.Point(189, 237);
            this.textBoxAppID.Name = "textBoxAppID";
            this.textBoxAppID.Size = new System.Drawing.Size(190, 20);
            this.textBoxAppID.TabIndex = 18;
            this.textBoxAppID.Visible = false;
            // 
            // labelAppID
            // 
            this.labelAppID.AutoSize = true;
            this.labelAppID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAppID.Location = new System.Drawing.Point(6, 237);
            this.labelAppID.Name = "labelAppID";
            this.labelAppID.Size = new System.Drawing.Size(59, 20);
            this.labelAppID.TabIndex = 17;
            this.labelAppID.Text = "AppID:";
            this.labelAppID.Visible = false;
            // 
            // buttonClose
            // 
            this.buttonClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClose.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonClose.Location = new System.Drawing.Point(178, 315);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(91, 29);
            this.buttonClose.TabIndex = 19;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(687, 297);
            this.tabControl1.TabIndex = 20;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.labelFoldersConfigsPath);
            this.tabPage1.Controls.Add(this.labelIFolderWatcher);
            this.tabPage1.Controls.Add(this.textBoxIFolderWatcher);
            this.tabPage1.Controls.Add(this.textBoxAppID);
            this.tabPage1.Controls.Add(this.textBoxFoldersConfigsPath);
            this.tabPage1.Controls.Add(this.labelAppID);
            this.tabPage1.Controls.Add(this.labelIFolderEventsHandler);
            this.tabPage1.Controls.Add(this.textBoxIFolderEventsHandler);
            this.tabPage1.Controls.Add(this.checkBoxWindows10Notification);
            this.tabPage1.Controls.Add(this.labelIOperationEventFactory);
            this.tabPage1.Controls.Add(this.checkBoxJsonFile);
            this.tabPage1.Controls.Add(this.textBoxIOperationEventFactory);
            this.tabPage1.Controls.Add(this.checkBoxConsole);
            this.tabPage1.Controls.Add(this.labelLoggerTypes);
            this.tabPage1.Controls.Add(this.checkBoxTextFile);
            this.tabPage1.Controls.Add(this.buttonBrowseFolderConfigsPath);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(679, 271);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.buttonAddFolderConfig);
            this.tabPage2.Controls.Add(this.dataGridViewFolderConfigs);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(679, 271);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridViewFolderConfigs
            // 
            this.dataGridViewFolderConfigs.AllowUserToAddRows = false;
            this.dataGridViewFolderConfigs.AllowUserToDeleteRows = false;
            this.dataGridViewFolderConfigs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFolderConfigs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnFolderPath,
            this.ColumnIncludeSubDirectories,
            this.ColumnWatchHiddenFiles});
            this.dataGridViewFolderConfigs.Location = new System.Drawing.Point(6, 46);
            this.dataGridViewFolderConfigs.Name = "dataGridViewFolderConfigs";
            this.dataGridViewFolderConfigs.Size = new System.Drawing.Size(667, 150);
            this.dataGridViewFolderConfigs.TabIndex = 0;
            // 
            // ColumnFolderPath
            // 
            this.ColumnFolderPath.HeaderText = "FolderPath";
            this.ColumnFolderPath.Name = "ColumnFolderPath";
            this.ColumnFolderPath.Width = 300;
            // 
            // ColumnIncludeSubDirectories
            // 
            this.ColumnIncludeSubDirectories.HeaderText = "IncludeSubDirectories";
            this.ColumnIncludeSubDirectories.Name = "ColumnIncludeSubDirectories";
            // 
            // ColumnWatchHiddenFiles
            // 
            this.ColumnWatchHiddenFiles.HeaderText = "WatchHiddenFiles";
            this.ColumnWatchHiddenFiles.Name = "ColumnWatchHiddenFiles";
            // 
            // buttonAddFolderConfig
            // 
            this.buttonAddFolderConfig.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.buttonAddFolderConfig.Location = new System.Drawing.Point(548, 17);
            this.buttonAddFolderConfig.Name = "buttonAddFolderConfig";
            this.buttonAddFolderConfig.Size = new System.Drawing.Size(125, 23);
            this.buttonAddFolderConfig.TabIndex = 8;
            this.buttonAddFolderConfig.Text = "Add FolderConfig";
            this.buttonAddFolderConfig.UseVisualStyleBackColor = true;
            this.buttonAddFolderConfig.Click += new System.EventHandler(this.ButtonAddFolderConfig_Click);
            // 
            // FolderWatcherConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 350);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonSaveConfiguration);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FolderWatcherConfigurationForm";
            this.Text = "Folder Watcher Configuration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WinForm_FormClosing);
            this.Load += new System.EventHandler(this.WinForm_Load);
            this.customContextMenu.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFolderConfigs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon customNotifyIcon;
        private System.Windows.Forms.ContextMenuStrip customContextMenu;
        private System.Windows.Forms.ToolStripMenuItem OpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label labelIFolderWatcher;
        private System.Windows.Forms.TextBox textBoxIFolderWatcher;
        private System.Windows.Forms.TextBox textBoxFoldersConfigsPath;
        private System.Windows.Forms.Label labelFoldersConfigsPath;
        private System.Windows.Forms.TextBox textBoxIFolderEventsHandler;
        private System.Windows.Forms.Label labelIFolderEventsHandler;
        private System.Windows.Forms.TextBox textBoxIOperationEventFactory;
        private System.Windows.Forms.Label labelIOperationEventFactory;
        private System.Windows.Forms.Label labelLoggerTypes;
        private System.Windows.Forms.Button buttonBrowseFolderConfigsPath;
        private System.Windows.Forms.OpenFileDialog openFileDialogFolderConfigsPath;
        private System.Windows.Forms.CheckBox checkBoxTextFile;
        private System.Windows.Forms.CheckBox checkBoxConsole;
        private System.Windows.Forms.CheckBox checkBoxJsonFile;
        private System.Windows.Forms.CheckBox checkBoxWindows10Notification;
        private System.Windows.Forms.Button buttonSaveConfiguration;
        private System.Windows.Forms.TextBox textBoxAppID;
        private System.Windows.Forms.Label labelAppID;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridViewFolderConfigs;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFolderPath;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnIncludeSubDirectories;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnWatchHiddenFiles;
        private System.Windows.Forms.Button buttonAddFolderConfig;
    }
}

