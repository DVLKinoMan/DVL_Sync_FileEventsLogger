using System.IO;
using Newtonsoft.Json;
using DVL_Sync_FileEventsLogger.Abstractions;
using DVL_Sync_FileEventsLogger.Models;
using System.Extensions;
using System;
using System.Diagnostics;

namespace DVL_Sync_FileEventsLogger.Implementations
{
    public sealed class FolderEventsLoggerInJsonFile : IFolderEventsLogger
    {
        private readonly FolderConfig folderConfig;
        private readonly Func<DateTime, string> logFilePathFunc;

        public FolderEventsLoggerInJsonFile(FolderConfig folderConfig, Func<DateTime, string> logFilePathFunc)=>
            (this.folderConfig,this.logFilePathFunc) = (folderConfig, logFilePathFunc);

        //public void Dispose() => streamWriter.Dispose();
        public void Dispose() { }

        public void LogOperation<TOperation>(TOperation operation) where TOperation : OperationEvent
        {
            try
            {
                if (!folderConfig.IsValid(operation, jsonLogFileName: Constants.JsonLogFileName)) 
                    return;

                using var streamWriter = new StreamWriter(logFilePathFunc(DateTime.Now), true).SetAttributeToHidden();
                streamWriter.WriteLine(JsonConvert.SerializeObject(operation));
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
            catch (Exception exc) {
                Console.WriteLine(exc.ToString());
            }
        }
    }
}
