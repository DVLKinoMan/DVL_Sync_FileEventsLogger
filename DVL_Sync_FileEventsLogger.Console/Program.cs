using DVL_Sync_FileEventsLogger.Domain.Extensions;
using System;
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
                $"{AppContext.BaseDirectory}/{configName}".GetFoldersWatcherConfig().GetFolderWatchers();
            watcher.StartWatching();

            Thread.Sleep(Timeout.Infinite);
        }
    }
}
