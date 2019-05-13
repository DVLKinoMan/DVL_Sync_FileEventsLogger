using System.IO;
//using DVL_Sync_FileEventsLogger.Domain.Extensions;
using Newtonsoft.Json;
//using System.Extensions;
using DVL_Sync_FileEventsLogger.Abstractions;
using DVL_Sync_FileEventsLogger.Models;

namespace DVL_Sync_FileEventsLogger.Implementations
{
    public sealed class FolderEventsLoggerInJsonFile : IFolderEventsLogger
    {
        private readonly StreamWriter streamWriter;
        private readonly FolderConfig folderConfig;

        public FolderEventsLoggerInJsonFile(FolderConfig folderConfig, StreamWriter streamWriter)
        {

            //var fullPath = $"{folderConfig.FolderPath}/{Constants.JsonLogFileName}";
            this.streamWriter = streamWriter;
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
