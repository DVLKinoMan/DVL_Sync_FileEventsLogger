using DVL_Sync_FileEventsLogger.Domain.Abstractions;
using DVL_Sync_FileEventsLogger.Domain.Extensions;
using DVL_Sync_FileEventsLogger.Domain.Implementations;
using System.ServiceProcess;
using System.Threading;
using static DVL_Sync_FileEventsLogger.Domain.Extensions.FolderConfigExts;

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
            IOperationEventFactory operationEventFactory = new OperationEventFactory();
            IFolderEventsLogger logger = new FolderEventsLoggerInConsole();
            IFolderEventsHandler handler = new FolderEventsHandlerViaLogging(operationEventFactory, logger);

            var foldersConfigs = @"C:\DVL_Sync_FileEventsLogger\FoldersConfigs.json".GetFolderConfigs();
            var watcher = new FoldersWatcherFactoryViaFileSystemWatcher().CreateFoldersWatcher(handler, foldersConfigs);
            watcher.StartWatching();
            Thread.Sleep(Timeout.Infinite);
        }

        protected override void OnStop()
        {
            // TODO: Add code here to perform any tear-down necessary to stop your service.
        }
    }
}
