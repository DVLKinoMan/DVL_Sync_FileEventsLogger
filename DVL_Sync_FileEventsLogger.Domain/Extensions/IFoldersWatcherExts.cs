using DVL_Sync_FileEventsLogger.Domain.Abstractions;
using System.Collections.Generic;

namespace DVL_Sync_FileEventsLogger.Domain.Extensions
{
    public static class IFoldersWatcherExts
    {
        public static void StartWatching(this IEnumerable<IFolderWatcher> watchers)
        {
            foreach (var watcher in watchers)
                watcher.StartWatching();
        }
    }
}
