using System.Extensions;
using DVL_Sync_FileEventsLogger.Extensions;
using System.Reflection;
using System.ServiceProcess;
using System.Threading;

namespace DVL_Sync_FileEventsLogger
{
    partial class EventsLoggerService : ServiceBase
    {
        public EventsLoggerService() => InitializeComponent();

        public void OnDebug() => OnStart(null);

        protected override void OnStart(string[] args)
        {
            string configName = "config.json";

            var watcher =
                $"{Assembly.GetAssembly(typeof(ProjectInstaller)).Location.GetDirectoryPath()}/{configName}".GetFoldersWatcherConfig().GetFolderWatchers();
            watcher.StartWatching();

            Thread.Sleep(Timeout.Infinite);
        }

        protected override void OnStop()
        {
            // TODO: Add code here to perform any tear-down necessary to stop your service.
        }
    }
}
