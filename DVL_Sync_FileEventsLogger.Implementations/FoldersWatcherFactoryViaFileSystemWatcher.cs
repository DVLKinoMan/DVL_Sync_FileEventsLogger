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
            using var handleIt = folderEventsHandlers.GetEnumerator();
            using var configIt = foldersConfigs.GetEnumerator();

            return Impl(handleIt, configIt);

            static IEnumerable<IFolderWatcher> Impl(IEnumerator<IFolderEventsHandler> handlerIterator, IEnumerator<FolderConfig> configIterator)
            {
                while (handlerIterator.MoveNext() && configIterator.MoveNext())
                {
                    IFolderWatcherFactory
                        watcherFactory = new FolderWatcherFactoryViaFileSystemWatcher();
                    yield return watcherFactory.CreateFolderWatcher(handlerIterator.Current, configIterator.Current);
                }
            }
        }
    }
}
