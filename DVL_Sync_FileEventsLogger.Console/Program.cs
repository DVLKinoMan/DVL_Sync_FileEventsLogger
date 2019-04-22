using DVL_Sync_FileEventsLogger.Domain.Abstractions;
using DVL_Sync_FileEventsLogger.Domain.Extensions;
using DVL_Sync_FileEventsLogger.Domain.Implementations;
using System.Threading;
using static DVL_Sync_FileEventsLogger.Domain.Extensions.FolderConfigExts;

namespace DVL_Sync_FileEventsLogger.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            IOperationEventFactory operationEventFactory = new OperationEventFactory();
            IFolderEventsLogger logger = new FolderEventsLoggerInConsole();
            IFolderEventsHandler handler = new FolderEventsHandlerViaLogging(operationEventFactory, logger);

            var foldersConfigs = GetFolderConfigsFromPath(@"C:\DVL_Sync_FileEventsLogger\FoldersConfigs.json");
            var watcher = new FoldersWatcherFactoryViaFileSystemWatcher().CreateFoldersWatcher(handler, foldersConfigs);
            watcher.StartWatching();
            Thread.Sleep(Timeout.Infinite);
        }
    }
}
