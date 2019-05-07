//using DVL_Sync_FileEventsLogger.Domain.Implementations;

using DVL_Sync_FileEventsLogger.Models;

namespace DVL_Sync_FileEventsLogger.Abstractions
{
    public interface IFolderEventsLoggerFactory
    {
        //IFolderEventsLogger CreateFolderEventsLogger(LoggerType loggerType, FolderConfig folderConfig);
        IFolderEventsLogger CreateLoggerInConsole(FolderConfig folderConfig);
        IFolderEventsLogger CreateLoggerInTextFile(FolderConfig folderConfig);
        IFolderEventsLogger CreateLoggerInJsonFile(FolderConfig folderConfig);
        IFolderEventsLogger CreateLoggerAsWindows10Notification(FolderConfig folderConfig, string appid);
    }
}
