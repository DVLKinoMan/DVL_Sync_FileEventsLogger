namespace DVL_Sync_FileEventsLogger.WinForm
{
    partial class WinForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WinForm));
            this.customNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.customContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dsafdadfToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelIFolderWatcher = new System.Windows.Forms.Label();
            this.textBoxIFolderWatcher = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.labelFoldersConfigsPath = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonBrowseFolderConfigsPath = new System.Windows.Forms.Button();
            this.openFileDialogFolderConfigsPath = new System.Windows.Forms.OpenFileDialog();
            this.customContextMenu.SuspendLayout();
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
            this.dsafdadfToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.customContextMenu.Name = "customContextMenu";
            this.customContextMenu.Size = new System.Drawing.Size(105, 48);
            // 
            // dsafdadfToolStripMenuItem
            // 
            this.dsafdadfToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dsafdadfToolStripMenuItem.Name = "dsafdadfToolStripMenuItem";
            this.dsafdadfToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.dsafdadfToolStripMenuItem.Text = "Open";
            this.dsafdadfToolStripMenuItem.Click += new System.EventHandler(this.DsafdadfToolStripMenuItem_Click);
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
            this.labelIFolderWatcher.Location = new System.Drawing.Point(46, 74);
            this.labelIFolderWatcher.Name = "labelIFolderWatcher";
            this.labelIFolderWatcher.Size = new System.Drawing.Size(123, 20);
            this.labelIFolderWatcher.TabIndex = 1;
            this.labelIFolderWatcher.Text = "IFolderWatcher:";
            // 
            // textBoxIFolderWatcher
            // 
            this.textBoxIFolderWatcher.Location = new System.Drawing.Point(225, 74);
            this.textBoxIFolderWatcher.Name = "textBoxIFolderWatcher";
            this.textBoxIFolderWatcher.Size = new System.Drawing.Size(190, 20);
            this.textBoxIFolderWatcher.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(225, 117);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(190, 20);
            this.textBox1.TabIndex = 4;
            // 
            // labelFoldersConfigsPath
            // 
            this.labelFoldersConfigsPath.AutoSize = true;
            this.labelFoldersConfigsPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFoldersConfigsPath.Location = new System.Drawing.Point(46, 117);
            this.labelFoldersConfigsPath.Name = "labelFoldersConfigsPath";
            this.labelFoldersConfigsPath.Size = new System.Drawing.Size(153, 20);
            this.labelFoldersConfigsPath.TabIndex = 3;
            this.labelFoldersConfigsPath.Text = "FoldersConfigsPath:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(225, 164);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(190, 20);
            this.textBox2.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(46, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "IFolderWatcher";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(225, 211);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(190, 20);
            this.textBox3.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(46, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "IFolderWatcher";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(225, 257);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(190, 20);
            this.textBox4.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(46, 257);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "IFolderWatcher";
            // 
            // buttonBrowseFolderConfigsPath
            // 
            this.buttonBrowseFolderConfigsPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBrowseFolderConfigsPath.Location = new System.Drawing.Point(421, 117);
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
            // WinForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 580);
            this.Controls.Add(this.buttonBrowseFolderConfigsPath);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.labelFoldersConfigsPath);
            this.Controls.Add(this.textBoxIFolderWatcher);
            this.Controls.Add(this.labelIFolderWatcher);
            this.Name = "WinForm";
            this.Text = "WinForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WinForm_FormClosing);
            this.Load += new System.EventHandler(this.WinForm_Load);
            this.customContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon customNotifyIcon;
        private System.Windows.Forms.ContextMenuStrip customContextMenu;
        private System.Windows.Forms.ToolStripMenuItem dsafdadfToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label labelIFolderWatcher;
        private System.Windows.Forms.TextBox textBoxIFolderWatcher;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label labelFoldersConfigsPath;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonBrowseFolderConfigsPath;
        private System.Windows.Forms.OpenFileDialog openFileDialogFolderConfigsPath;
    }
}

