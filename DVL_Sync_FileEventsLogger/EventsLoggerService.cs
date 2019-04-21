using DVL_Sync_FileEventsLogger.Domain.Abstractions;
using DVL_Sync_FileEventsLogger.Domain.Implementations;
using DVL_Sync_FileEventsLogger.Domain.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.ServiceProcess;
using System.Threading;
using DVL_Sync_FileEventsLogger.Domain.Extensions;

namespace DVL_Sync_FileEventsLogger
{
    partial class EventsLoggerService : ServiceBase
    {
        public EventsLoggerService()
        {
            InitializeComponent();
        }

        public void OnDebug()
        {
            OnStart(null);
        }

        protected override void OnStart(string[] args)
        {
            IFolderEventsLogger logger = new FolderEventsLoggerInFile(new StreamWriter("LogFile.txt", true));
            IFolderEventsHandler handler = new FolderEventsHandlerViaLogging(logger);

            using (StreamReader r = new StreamReader("FoldersConfigs.json"))
            {
                string json = r.ReadToEnd();
                var foldersConfigs = JsonConvert.DeserializeObject<IEnumerable<FolderConfig>>(json);
                IEnumerable<IFolderWatcher> watcher = new FoldersWatcherFactoryViaFileSystemWatcher().CreateFoldersWatcher(handler, foldersConfigs);
                watcher.StartWatching();
                Thread.Sleep(Timeout.Infinite);
            }
        }

        protected override void OnStop()
        {
            // TODO: Add code here to perform any tear-down necessary to stop your service.
        }
    }
}
