using DVL_Sync_FileEventsLogger.Domain.Abstractions;
using DVL_Sync_FileEventsLogger.Domain.Models;

namespace DVL_Sync_FileEventsLogger.Domain.Implementations
{
    public class FolderWatcherFactoryViaFileSystemWatcher : IFolderWatcherFactory
    {
        public IFolderWatcher CreateFolderWatcher(IFolderEventsHandler folderEventsHandler, FolderConfig folderConfig) => new CustomFileSystemWatcher(folderEventsHandler, folderConfig);
    }
}
