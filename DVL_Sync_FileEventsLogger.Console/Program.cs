using DVL_Sync_FileEventsLogger.Domain.Abstractions;
using DVL_Sync_FileEventsLogger.Domain.Extensions;
using DVL_Sync_FileEventsLogger.Domain.Implementations;
//using DVL_Sync_FileEventsLogger.DomainOnWindows.Helpers;
using DVL_Sync_FileEventsLogger.DomainOnWindows.Implementations;
using System.Threading;
using static DVL_Sync_FileEventsLogger.Domain.Extensions.FolderConfigExts;

namespace DVL_Sync_FileEventsLogger.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string appid = "DVL_Sync_EventLogger";
            //Windows10NotificationsHelper.TryCreateShortcut(appid);

            IOperationEventFactory operationEventFactory = new OperationEventFactory();
            IFolderEventsLogger logger = new FolderEventsLoggerInWindows10Notifications(appid);
            IFolderEventsHandler handler = new FolderEventsHandlerViaLogging(operationEventFactory, logger);

            var foldersConfigs = GetFolderConfigsFromPath(@"C:\DVL_Sync_FileEventsLogger\FoldersConfigs.json");
            var watcher =
                new FoldersWatcherFactoryViaFileSystemWatcher().CreateFoldersWatcher(handler, foldersConfigs);
            watcher.StartWatching();
            Thread.Sleep(Timeout.Infinite);
        }
    }
}
