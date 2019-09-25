using System.IO;
//using DVL_Sync_FileEventsLogger.Domain.Extensions;
using Newtonsoft.Json;
//using System.Extensions;
using DVL_Sync_FileEventsLogger.Abstractions;
using DVL_Sync_FileEventsLogger.Models;
using System.Extensions;
using System;

namespace DVL_Sync_FileEventsLogger.Implementations
{
    public sealed class FolderEventsLoggerInJsonFile : IFolderEventsLogger
    {
        //private readonly StreamWriter streamWriter;
        private readonly string logFilePath;
        private readonly FolderConfig folderConfig;

        public FolderEventsLoggerInJsonFile(FolderConfig folderConfig, string logFilePath)
        {

            //var fullPath = $"{folderConfig.FolderPath}/{Constants.JsonLogFileName}";
            //this.streamWriter = streamWriter;
            this.folderConfig = folderConfig;
            this.logFilePath = logFilePath;
        }

        //public void Dispose() => streamWriter.Dispose();
        public void Dispose() { }

        public void LogOperation<Operation>(Operation operation) where Operation : OperationEvent
        {
            try
            {
                if (folderConfig.IsValid(operation, jsonLogFileName: Constants.JsonLogFileName))
                    using (var streamWriter = new StreamWriter(logFilePath, true).SetAttributeToHidden())
                        streamWriter.WriteLine(JsonConvert.SerializeObject(operation));
            }
#if NETFRAMEWORK
            catch (Exception exc)
            {
                using (EventLog eventLog = new EventLog("Application"))
                {
                    eventLog.Source = "Application";
                    eventLog.WriteEntry(exc.ToString());
                    eventLog.WriteEntry("Log message example", EventLogEntryType.Information, 101, 1);
                }
            }
#endif
            catch (Exception exc) {
                Console.WriteLine(exc.ToString());
            }
        }
    }
}
