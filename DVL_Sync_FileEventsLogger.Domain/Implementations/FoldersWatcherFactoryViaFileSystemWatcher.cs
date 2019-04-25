using DVL_Sync_FileEventsLogger.Domain.Abstractions;
using DVL_Sync_FileEventsLogger.Domain.Models;
using System.Collections.Generic;

namespace DVL_Sync_FileEventsLogger.Domain.Implementations
{
    public sealed class FoldersWatcherFactoryViaFileSystemWatcher : IFoldersWatcherFactory
    {
        public IEnumerable<IFolderWatcher> CreateFoldersWatcher(IFolderEventsHandler folderEventsHandler,
            IEnumerable<FolderConfig> foldersConfigs)
        {
            var watchers = new List<IFolderWatcher>();
            foreach (var folderConfig in foldersConfigs)
            {
                IFolderWatcherFactory
                    watcherFactory = new FolderWatcherFactoryViaFileSystemWatcher();
                watchers.Add(watcherFactory.CreateFolderWatcher(folderEventsHandler, folderConfig));
            }

            return watchers;
        }
    }
}
