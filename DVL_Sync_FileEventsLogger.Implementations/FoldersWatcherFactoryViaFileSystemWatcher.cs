using System.Collections.Generic;
using DVL_Sync_FileEventsLogger.Abstractions;
using DVL_Sync_FileEventsLogger.Models;

namespace DVL_Sync_FileEventsLogger.Implementations
{
    public sealed class FoldersWatcherFactoryViaFileSystemWatcher : IFoldersWatcherFactory
    {
        public IEnumerable<IFolderWatcher> CreateFoldersWatcher(IEnumerable<IFolderEventsHandler> folderEventsHandlers,
            IEnumerable<FolderConfig> foldersConfigs)
        {
            var handlerIterator = folderEventsHandlers.GetEnumerator();
            var configIterator = foldersConfigs.GetEnumerator();

            while (handlerIterator.MoveNext() && configIterator.MoveNext())
            {
                IFolderWatcherFactory
                    watcherFactory = new FolderWatcherFactoryViaFileSystemWatcher();
                yield return watcherFactory.CreateFolderWatcher(handlerIterator.Current, configIterator.Current);
            }
        }
    }
}
