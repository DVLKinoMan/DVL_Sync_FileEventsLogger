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

        public FolderEventsLoggerInJsonFile(StreamWriter stream, FolderConfig folderConfig)
        {
            streamWriter = stream;
            streamWriter.AutoFlush = true;
            this.folderConfig = folderConfig;
        }

        public void LogOperation<Operation>(Operation operation) where Operation : OperationEvent
        {
            if (folderConfig.IsValid(operation))
                streamWriter.WriteLine(JsonConvert.SerializeObject(operation));
        }
    }
}
