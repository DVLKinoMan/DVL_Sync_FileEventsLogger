using DVL_Sync_FileEventsLogger.Domain.Abstractions;
//using System;
//using System.IO;
using DVL_Sync_FileEventsLogger.Domain.Models;

namespace DVL_Sync_FileEventsLogger.Domain.Implementations
{
    public class FolderEventsLoggerFactory : IFolderEventsLoggerFactory
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

        public IFolderEventsLogger CreateLoggerInTextFile(FolderConfig folderConfig) =>
            new FolderEventsLoggerInFile(folderConfig);
        //{
        //    var fullPath = $"{folderConfig.FolderPath}/{Constants.TextLogFileName}";
        //    var stream = new StreamWriter(fullPath, true);
        //    var flInfo = new FileInfo(fullPath);
        //    flInfo.Attributes = flInfo.Attributes | FileAttributes.Hidden;

        //    return new FolderEventsLoggerInFile(stream, folderConfig);
        //}

        public IFolderEventsLogger CreateLoggerInJsonFile(FolderConfig folderConfig) =>
            new FolderEventsLoggerInJsonFile(folderConfig);
        //{
        //    var fullPath2 = $"{folderConfig.FolderPath}/{Constants.JsonLogFileName}";
        //    var stream2 = new StreamWriter(fullPath2, true);
        //    var flInfo2 = new FileInfo(fullPath2);
        //    flInfo2.Attributes = flInfo2.Attributes | FileAttributes.Hidden;

        //    return new FolderEventsLoggerInJsonFile(stream2, folderConfig);
        //}

    }
}
