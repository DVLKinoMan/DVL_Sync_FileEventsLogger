using DVL_Sync_FileEventsLogger.Domain.Implementations;
using DVL_Sync_FileEventsLogger.Domain.Models;

namespace DVL_Sync_FileEventsLogger.Domain.Abstractions
{
    public interface IFolderEventsLoggerFactory
    {
        IFolderEventsLogger CreateFolderEventsLogger(LoggerType loggerType, FolderConfig folderConfig);
    }
}
