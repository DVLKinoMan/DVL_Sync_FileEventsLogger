using DVL_Sync_FileEventsLogger.Abstractions;
using DVL_Sync_FileEventsLogger.Models;

namespace DVL_Sync_FileEventsLogger.Implementations
{
    internal sealed class FolderWatcherFactoryViaFileSystemWatcher : IFolderWatcherFactory
    {
        public IFolderWatcher CreateFolderWatcher(IFolderEventsHandler folderEventsHandler, FolderConfig folderConfig) => new CustomFileSystemWatcher(folderEventsHandler, folderConfig);
    }
}
