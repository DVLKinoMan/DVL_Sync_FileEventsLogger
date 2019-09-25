//using DVL_Sync_FileEventsLogger.Domain.Extensions;
using System;
using System.Extensions;
using System.IO;
//using System.Extensions;
using DVL_Sync_FileEventsLogger.Abstractions;
using DVL_Sync_FileEventsLogger.Models;
using System.Diagnostics;

namespace DVL_Sync_FileEventsLogger.Implementations
{
    public sealed class FolderEventsLoggerInFile : IFolderEventsLogger
    {
        //private readonly StreamWriter streamWriter;
        //private readonly string logFilePath;
        private readonly FolderConfig folderConfig;
        private readonly Func<DateTime, string> logFilePathFunc;

        public FolderEventsLoggerInFile(FolderConfig folderConfig, Func<DateTime, string> logFilePathFunc)
        {
            //var fullPath = $"{folderConfig.FolderPath}/{Constants.TextLogFileName}";
            //this.streamWriter = streamWriter;
            //this.logFilePath = logFilePath;
            this.logFilePathFunc = logFilePathFunc;
            this.folderConfig = folderConfig;
        }

        public void Dispose() { }

        public void LogOperation<Operation>(Operation operation) where Operation : OperationEvent
        {
            try
            {
                if (folderConfig.IsValid(operation, textLogFileName: Constants.TextLogFileName))
                    //using (var streamWriter = new StreamWriter(logFilePath, true).SetAttributeToHidden())
                    using (var streamWriter = new StreamWriter(logFilePathFunc(DateTime.Now), true).SetAttributeToHidden())
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
