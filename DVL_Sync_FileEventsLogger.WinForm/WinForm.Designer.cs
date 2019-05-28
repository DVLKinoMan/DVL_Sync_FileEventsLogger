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
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exitToolStripMenuItem.Image")));
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // WinForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 580);
            this.Name = "WinForm";
            this.Text = "WinForm";
            this.customContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon customNotifyIcon;
        private System.Windows.Forms.ContextMenuStrip customContextMenu;
        private System.Windows.Forms.ToolStripMenuItem dsafdadfToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

