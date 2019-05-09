﻿//using DVL_Sync_FileEventsLogger.Domain.Implementations;

using System.IO;
using DVL_Sync_FileEventsLogger.Models;

namespace DVL_Sync_FileEventsLogger.Abstractions
{
    public interface IFolderEventsLoggerFactory
    {
        //IFolderEventsLogger CreateFolderEventsLogger(LoggerType loggerType, FolderConfig folderConfig);
        IFolderEventsLogger CreateLoggerInConsole(FolderConfig folderConfig);
        IFolderEventsLogger CreateLoggerInTextFile(FolderConfig folderConfig, StreamWriter streamWriter);
        IFolderEventsLogger CreateLoggerInJsonFile(FolderConfig folderConfig, StreamWriter streamWriter);
        IFolderEventsLogger CreateLoggerAsWindows10Notification(FolderConfig folderConfig, string appid);
    }
}
