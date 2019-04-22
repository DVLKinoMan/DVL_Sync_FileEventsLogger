using DVL_Sync_FileEventsLogger.Domain.Abstractions;
using DVL_Sync_FileEventsLogger.Domain.Models;
using System.IO;

namespace DVL_Sync_FileEventsLogger.Domain.Implementations
{
    public class FolderEventsLoggerInFile : IFolderEventsLogger
    {
        private readonly StreamWriter streamWriter;

        public FolderEventsLoggerInFile(StreamWriter stream)
        {
            streamWriter = stream;
            streamWriter.AutoFlush = true;
        }

        public void LogOperation<Operation>(Operation operation) where Operation : OperationEvent =>
            streamWriter.WriteLine(operation);
    }
}
