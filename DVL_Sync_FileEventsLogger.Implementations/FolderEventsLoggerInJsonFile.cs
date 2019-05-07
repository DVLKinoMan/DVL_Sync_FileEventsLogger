using System.IO;
//using DVL_Sync_FileEventsLogger.Domain.Extensions;
using Newtonsoft.Json;
using System.Extensions;
using DVL_Sync_FileEventsLogger.Abstractions;
using DVL_Sync_FileEventsLogger.Models;

namespace DVL_Sync_FileEventsLogger.Implementations
{
    class FolderEventsLoggerInJsonFile : IFolderEventsLogger
    {
        private readonly StreamWriter streamWriter;
        private readonly FolderConfig folderConfig;

        public FolderEventsLoggerInJsonFile(FolderConfig folderConfig)
        {

            var fullPath = $"{folderConfig.FolderPath}/{Constants.JsonLogFileName}";
            this.streamWriter = new StreamWriter(fullPath, true).SetAttributeToHidden().SetAutoFlush();
            this.folderConfig = folderConfig;
        }

        public void Dispose() => streamWriter.Dispose();

        public void LogOperation<Operation>(Operation operation) where Operation : OperationEvent
        {
            if (folderConfig.IsValid(operation, jsonLogFileName: Constants.JsonLogFileName))
                streamWriter.WriteLine(JsonConvert.SerializeObject(operation));
        }
    }
}
