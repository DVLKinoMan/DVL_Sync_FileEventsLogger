using System;
using System.Windows.Forms;

namespace DVL_Sync_FileEventsLogger.WinForm
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FolderWatcherConfigurationForm());
        }
    }
}
