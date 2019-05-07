using System.Collections.Generic;
using DVL_Sync_FileEventsLogger.Models;

namespace DVL_Sync_FileEventsLogger.Abstractions
{
    public interface IFoldersWatcherFactory
    {
        IEnumerable<IFolderWatcher> CreateFoldersWatcher(IEnumerable<IFolderEventsHandler> folderEventsHandler, IEnumerable<FolderConfig> foldersConfigs);
    }
}
