using DVL_Sync_FileEventsLogger.Domain.Models;

namespace DVL_Sync_FileEventsLogger.Domain.Abstractions
{
    public interface IFolderWatcherFactory
    {
        IFolderWatcher CreateFolderWatcher(IFolderEventsHandler folderEventsHandler, FolderConfig folderConfig);
    }
}
