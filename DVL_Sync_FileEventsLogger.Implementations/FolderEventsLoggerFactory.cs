using DVL_Sync_FileEventsLogger.Abstractions;
using DVL_Sync_FileEventsLogger.OnWindows.Implementations;
using DVL_Sync_FileEventsLogger.Models;
using System;

namespace DVL_Sync_FileEventsLogger.Implementations
{
    public sealed class FolderEventsLoggerFactory : IFolderEventsLoggerFactory
    {

        public IFolderEventsLogger CreateLoggerInConsole(FolderConfig folderConfig) =>
            new FolderEventsLoggerInConsole(folderConfig);

        public IFolderEventsLogger CreateLoggerInTextFile(FolderConfig folderConfig, Func<DateTime,string> logFilePathFunc) =>
            new FolderEventsLoggerInFile(folderConfig, logFilePathFunc);

        public IFolderEventsLogger CreateLoggerInJsonFile(FolderConfig folderConfig, Func<DateTime, string> logFilePathFunc) =>
            new FolderEventsLoggerInJsonFile(folderConfig, logFilePathFunc);

        public IFolderEventsLogger CreateLoggerAsWindows10Notification(FolderConfig folderConfig, string appid) =>
            new FolderEventsLoggerInWindows10Notifications(folderConfig, appid);
    }
}
