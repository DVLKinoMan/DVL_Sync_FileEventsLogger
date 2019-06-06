using System.Collections.Generic;
using DVL_Sync_FileEventsLogger.Abstractions;

namespace DVL_Sync_FileEventsLogger.Extensions
{
    public static class IFoldersWatcherExts
    {
        public static void StartWatching(this IEnumerable<IFolderWatcher> watchers)
        {
            foreach (var watcher in watchers)
                watcher.StartWatching();
        }

        public static void Dispose(this IEnumerable<IFolderWatcher> watchers)
        {
            foreach (var watcher in watchers)
                watcher.Dispose();
        }
    }
}
