using DVL_Sync_FileEventsLogger.Abstractions;
//using System;
//using System.IO;
using DVL_Sync_FileEventsLogger.OnWindows.Implementations;
using DVL_Sync_FileEventsLogger.Models;
using System;
//using System.IO;

namespace DVL_Sync_FileEventsLogger.Implementations
{
    public sealed class FolderEventsLoggerFactory : IFolderEventsLoggerFactory
    {
        //public IFolderEventsLogger CreateFolderEventsLogger(LoggerType loggerType, FolderConfig folderConfig)
        //{
        //    if (folderConfig != null && !Directory.Exists(folderConfig.FolderPath))
        //        throw new DirectoryNotFoundException($"Directory on Path {folderConfig.FolderPath} Not Found");

        //    switch (loggerType)
        //    {
        //        case LoggerType.Console:
        //            return new FolderEventsLoggerInConsole(folderConfig);
        //        case LoggerType.TextFile:

        //            var fullPath = $"{folderConfig.FolderPath}/{Constants.TextLogFileName}";
        //            var stream = new StreamWriter(fullPath, true);
        //            var flInfo = new FileInfo(fullPath);
        //            flInfo.Attributes = flInfo.Attributes | FileAttributes.Hidden;

        //            return new FolderEventsLoggerInFile(stream, folderConfig);
        //        case LoggerType.JsonFile:

        //            var fullPath2 = $"{folderConfig.FolderPath}/{Constants.JsonLogFileName}";
        //            var stream2 = new StreamWriter(fullPath2, true);
        //            var flInfo2 = new FileInfo(fullPath2);
        //            flInfo2.Attributes = flInfo2.Attributes | FileAttributes.Hidden;

        //            return new FolderEventsLoggerInJsonFile(stream2, folderConfig);
        //        default:
        //            throw new ArgumentException("loggerType");
        //    }
        //}

        public IFolderEventsLogger CreateLoggerInConsole(FolderConfig folderConfig) =>
            new FolderEventsLoggerInConsole(folderConfig);

        public IFolderEventsLogger CreateLoggerInTextFile(FolderConfig folderConfig, Func<DateTime,string> logFilePathFunc) =>
            new FolderEventsLoggerInFile(folderConfig, logFilePathFunc);
        //{
        //    var fullPath = $"{folderConfig.FolderPath}/{Constants.TextLogFileName}";
        //    var stream = new StreamWriter(fullPath, true);
        //    var flInfo = new FileInfo(fullPath);
        //    flInfo.Attributes = flInfo.Attributes | FileAttributes.Hidden;

        //    return new FolderEventsLoggerInFile(stream, folderConfig);
        //}

        public IFolderEventsLogger CreateLoggerInJsonFile(FolderConfig folderConfig, Func<DateTime, string> logFilePathFunc) =>
            new FolderEventsLoggerInJsonFile(folderConfig, logFilePathFunc);
        //{
        //    var fullPath2 = $"{folderConfig.FolderPath}/{Constants.JsonLogFileName}";
        //    var stream2 = new StreamWriter(fullPath2, true);
        //    var flInfo2 = new FileInfo(fullPath2);
        //    flInfo2.Attributes = flInfo2.Attributes | FileAttributes.Hidden;

        //    return new FolderEventsLoggerInJsonFile(stream2, folderConfig);
        //}

        public IFolderEventsLogger CreateLoggerAsWindows10Notification(FolderConfig folderConfig, string appid) =>
            new FolderEventsLoggerInWindows10Notifications(folderConfig, appid);
    }
}
