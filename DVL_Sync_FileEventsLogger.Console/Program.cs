using DVL_Sync_FileEventsLogger.Extensions;
//using DVL_Sync_FileEventsLogger.DomainOnWindows.Helpers;
using System.Threading;

namespace DVL_Sync_FileEventsLogger.Console
{
    class Program
    {
        static void Main()
        {
            string configName = "config.json";

            var watcher =
                $"{System.Environment.CurrentDirectory}/{configName}".GetFoldersWatcherConfig().GetFolderWatchers();
            watcher.StartWatching();

            Thread.Sleep(Timeout.Infinite);
        }
    }
}
