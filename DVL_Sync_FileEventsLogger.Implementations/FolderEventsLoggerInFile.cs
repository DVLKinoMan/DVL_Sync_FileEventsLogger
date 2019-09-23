//using DVL_Sync_FileEventsLogger.Domain.Extensions;
using System.Extensions;
using System.IO;
//using System.Extensions;
using DVL_Sync_FileEventsLogger.Abstractions;
using DVL_Sync_FileEventsLogger.Models;

namespace DVL_Sync_FileEventsLogger.Implementations
{
    public sealed class FolderEventsLoggerInFile : IFolderEventsLogger
    {
        //private readonly StreamWriter streamWriter;
        private readonly string logFilePath;
        private readonly FolderConfig folderConfig;

        public FolderEventsLoggerInFile(FolderConfig folderConfig, string logFilePath)
        {
            //var fullPath = $"{folderConfig.FolderPath}/{Constants.TextLogFileName}";
            //this.streamWriter = streamWriter;
            this.logFilePath = logFilePath;
            this.folderConfig = folderConfig;
        }

        public void Dispose() { }

        public void LogOperation<Operation>(Operation operation) where Operation : OperationEvent
        {
            if (folderConfig.IsValid(operation, textLogFileName: Constants.TextLogFileName))
                using (var streamWriter = new StreamWriter(logFilePath, true).SetAttributeToHidden())
                    streamWriter.WriteLine(operation);
        }

    }
}
