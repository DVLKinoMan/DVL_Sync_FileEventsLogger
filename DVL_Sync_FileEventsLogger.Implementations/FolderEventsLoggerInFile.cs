﻿using System;
using System.Extensions;
using System.IO;
using DVL_Sync_FileEventsLogger.Abstractions;
using DVL_Sync_FileEventsLogger.Models;
using System.Diagnostics;

namespace DVL_Sync_FileEventsLogger.Implementations
{
    public sealed class FolderEventsLoggerInFile : IFolderEventsLogger
    {
        private readonly FolderConfig folderConfig;
        private readonly Func<DateTime, string> logFilePathFunc;

        public FolderEventsLoggerInFile(FolderConfig folderConfig, Func<DateTime, string> logFilePathFunc) => 
            (this.logFilePathFunc, this.folderConfig) = (logFilePathFunc,folderConfig);

        public void Dispose() { }

        public void LogOperation<TOperation>(TOperation operation) where TOperation : OperationEvent
        {
            try
            {
                if (!folderConfig.IsValid(operation, textLogFileName: Constants.TextLogFileName)) 
                    return;

                using var streamWriter = new StreamWriter(logFilePathFunc(DateTime.Now), true).SetAttributeToHidden();
                streamWriter.WriteLine(operation);
            }
#if NETFRAMEWORK
            catch (Exception exc)
            {
                using (var eventLog = new EventLog("Application"))
                {
                    eventLog.Source = "Application";
                    eventLog.WriteEntry(exc.ToString());
                }
            }
#endif
            catch (Exception exc)
            {
                Console.WriteLine(exc.ToString());
            }
        }

    }
}
