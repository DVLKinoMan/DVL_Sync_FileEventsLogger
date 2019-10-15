using DVL_Sync_FileEventsLogger.Extensions;
//using DVL_Sync_FileEventsLogger.DomainOnWindows.Helpers;
using System.Threading;

namespace DVL_Sync_FileEventsLogger.Console
{
    internal class Program
    {
        private static void Main()
        {
            const string configName = "config.json";

            var watcher =
                $"{System.Environment.CurrentDirectory}/{configName}".GetFoldersWatcherConfig().GetFolderWatchers();
            watcher.StartWatching();

            Thread.Sleep(Timeout.Infinite);
        }
    }
}
