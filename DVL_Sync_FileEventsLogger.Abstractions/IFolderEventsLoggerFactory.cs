//using DVL_Sync_FileEventsLogger.Domain.Implementations;

//using System.IO;
using DVL_Sync_FileEventsLogger.Models;

namespace DVL_Sync_FileEventsLogger.Abstractions
{
    public interface IFolderEventsLoggerFactory
    {
        //IFolderEventsLogger CreateFolderEventsLogger(LoggerType loggerType, FolderConfig folderConfig);
        IFolderEventsLogger CreateLoggerInConsole(FolderConfig folderConfig);
        IFolderEventsLogger CreateLoggerInTextFile(FolderConfig folderConfig, string lofFilePath);
        IFolderEventsLogger CreateLoggerInJsonFile(FolderConfig folderConfig, string logFolderPath);
        IFolderEventsLogger CreateLoggerAsWindows10Notification(FolderConfig folderConfig, string appid);
    }
}
