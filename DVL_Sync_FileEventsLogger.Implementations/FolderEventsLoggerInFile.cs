//using DVL_Sync_FileEventsLogger.Domain.Extensions;
using System.IO;
//using System.Extensions;
using DVL_Sync_FileEventsLogger.Abstractions;
using DVL_Sync_FileEventsLogger.Models;

namespace DVL_Sync_FileEventsLogger.Implementations
{
    public sealed class FolderEventsLoggerInFile : IFolderEventsLogger
    {
        private readonly StreamWriter streamWriter;
        private readonly FolderConfig folderConfig;

        public FolderEventsLoggerInFile(FolderConfig folderConfig, StreamWriter streamWriter)
        {
            //var fullPath = $"{folderConfig.FolderPath}/{Constants.TextLogFileName}";
            this.streamWriter = streamWriter;
            this.folderConfig = folderConfig;
        }

        public void Dispose() => streamWriter.Dispose();

        public void LogOperation<Operation>(Operation operation) where Operation : OperationEvent
        {
            if (folderConfig.IsValid(operation, textLogFileName: Constants.TextLogFileName))
                streamWriter.WriteLine(operation);
        }

    }
}
