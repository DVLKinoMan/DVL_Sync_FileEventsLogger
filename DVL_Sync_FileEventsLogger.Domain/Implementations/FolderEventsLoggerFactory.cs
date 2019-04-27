using DVL_Sync_FileEventsLogger.Domain.Abstractions;
using System;
using System.IO;
using DVL_Sync_FileEventsLogger.Domain.Models;

namespace DVL_Sync_FileEventsLogger.Domain.Implementations
{
    public class FolderEventsLoggerFactory : IFolderEventsLoggerFactory
    {
        public IFolderEventsLogger CreateFolderEventsLogger(LoggerType loggerType, FolderConfig folderConfig)
        {
            if (folderConfig != null && !Directory.Exists(folderConfig.FolderPath))
                throw new DirectoryNotFoundException($"Directory on Path {folderConfig.FolderPath} Not Found");

            switch (loggerType)
            {
                case LoggerType.Console:
                    return new FolderEventsLoggerInConsole(folderConfig);
                case LoggerType.TextFile:
                    return new FolderEventsLoggerInFile(
                        new StreamWriter($"{folderConfig.FolderPath}/{Constants.TextLogFileName}", true), folderConfig);
                case LoggerType.JsonFile:
                    return new FolderEventsLoggerInJsonFile(
                        new StreamWriter($"{folderConfig.FolderPath}/{Constants.JsonLogFileName}", true), folderConfig);
                default:
                    throw new ArgumentException("loggerType");
            }
        }
    }
}
