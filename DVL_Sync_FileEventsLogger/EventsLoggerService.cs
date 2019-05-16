//using System.ComponentModel;
using System.Collections.Generic;
using System.Extensions;
using DVL_Sync_FileEventsLogger.Extensions;
using System.Reflection;
using System.ServiceProcess;
//using System.Threading;
//using System.Threading;
//using System.Threading.Tasks;
using DVL_Sync_FileEventsLogger.Abstractions;

namespace DVL_Sync_FileEventsLogger
{
    partial class EventsLoggerService : ServiceBase
    {
        private IEnumerable<IFolderWatcher> watchers;

        public EventsLoggerService() => InitializeComponent();

        public void OnDebug() => OnStart(null);

        protected override void OnStart(string[] args)
        {
            string configName = "config.json";

            watchers =
                $"{Assembly.GetAssembly(typeof(ProjectInstaller)).Location.GetDirectoryPath()}/{configName}".GetFoldersWatcherConfig().GetFolderWatchers();
            watchers.StartWatching();
        }
        //Thread.Sleep(Timeout.Infinite);
        

        protected override void OnStop()
        {
            // TODO: Add code here to perform any tear-down necessary to stop your service.
        }
    }
}
