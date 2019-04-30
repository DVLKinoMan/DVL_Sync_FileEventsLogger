using DVL_Sync_FileEventsLogger.Domain.Abstractions;
using DVL_Sync_FileEventsLogger.Domain.Models;
using System.IO;
using DVL_Sync_FileEventsLogger.Domain.Extensions;
using Newtonsoft.Json;

namespace DVL_Sync_FileEventsLogger.Domain.Implementations
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
            if (folderConfig.IsValid(operation))
                streamWriter.WriteLine(JsonConvert.SerializeObject(operation));
        }
    }
}
