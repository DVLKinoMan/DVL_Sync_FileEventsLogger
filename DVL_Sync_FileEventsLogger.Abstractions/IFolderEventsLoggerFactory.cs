//using DVL_Sync_FileEventsLogger.Domain.Implementations;

//using System.IO;
using DVL_Sync_FileEventsLogger.Models;
using System;

namespace DVL_Sync_FileEventsLogger.Abstractions
{
    public interface IFolderEventsLoggerFactory
    {
        //IFolderEventsLogger CreateFolderEventsLogger(LoggerType loggerType, FolderConfig folderConfig);
        IFolderEventsLogger CreateLoggerInConsole(FolderConfig folderConfig);
        IFolderEventsLogger CreateLoggerInTextFile(FolderConfig folderConfig, Func<DateTime, string> logFilePathFunc);
        IFolderEventsLogger CreateLoggerInJsonFile(FolderConfig folderConfig, Func<DateTime, string> logFilePathFunc);
        IFolderEventsLogger CreateLoggerAsWindows10Notification(FolderConfig folderConfig, string appid);
    }
}
