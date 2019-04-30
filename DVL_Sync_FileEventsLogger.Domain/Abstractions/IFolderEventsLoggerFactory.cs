//using DVL_Sync_FileEventsLogger.Domain.Implementations;
using DVL_Sync_FileEventsLogger.Domain.Models;

namespace DVL_Sync_FileEventsLogger.Domain.Abstractions
{
    public interface IFolderEventsLoggerFactory
    {
        //IFolderEventsLogger CreateFolderEventsLogger(LoggerType loggerType, FolderConfig folderConfig);
        IFolderEventsLogger CreateLoggerInConsole(FolderConfig folderConfig);
        IFolderEventsLogger CreateLoggerInTextFile(FolderConfig folderConfig);
        IFolderEventsLogger CreateLoggerInJsonFile(FolderConfig folderConfig);
    }
}
