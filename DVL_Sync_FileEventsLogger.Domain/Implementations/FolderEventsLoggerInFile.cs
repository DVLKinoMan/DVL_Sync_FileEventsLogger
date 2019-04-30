using DVL_Sync_FileEventsLogger.Domain.Abstractions;
using DVL_Sync_FileEventsLogger.Domain.Extensions;
using DVL_Sync_FileEventsLogger.Domain.Models;
using System.IO;

namespace DVL_Sync_FileEventsLogger.Domain.Implementations
{
    public class FolderEventsLoggerInFile : IFolderEventsLogger
    {
        private readonly StreamWriter streamWriter;
        private readonly FolderConfig folderConfig;

        public FolderEventsLoggerInFile(FolderConfig folderConfig)
        {
            var fullPath = $"{folderConfig.FolderPath}/{Constants.TextLogFileName}";
            this.streamWriter = new StreamWriter(fullPath, true).SetAttributeToHidden().SetAutoFlush();
            this.folderConfig = folderConfig;
        }

        public void Dispose() => streamWriter.Dispose();

        public void LogOperation<Operation>(Operation operation) where Operation : OperationEvent
        {
            if (folderConfig.IsValid(operation))
                streamWriter.WriteLine(operation);
        }

    }
}
