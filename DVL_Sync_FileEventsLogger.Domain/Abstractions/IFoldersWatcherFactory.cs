using DVL_Sync_FileEventsLogger.Domain.Models;
using System.Collections.Generic;

namespace DVL_Sync_FileEventsLogger.Domain.Abstractions
{
    public interface IFoldersWatcherFactory
    {
        IEnumerable<IFolderWatcher> CreateFoldersWatcher(IEnumerable<IFolderEventsHandler> folderEventsHandler, IEnumerable<FolderConfig> foldersConfigs);
    }
}
