using DVL_Sync_FileEventsLogger.Models;

namespace DVL_Sync_FileEventsLogger.Abstractions
{
    public interface IFolderWatcherFactory
    {
        IFolderWatcher CreateFolderWatcher(IFolderEventsHandler folderEventsHandler, FolderConfig folderConfig);
    }
}
