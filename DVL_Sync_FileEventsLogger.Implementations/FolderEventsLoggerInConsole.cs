using System;
using DVL_Sync_FileEventsLogger.Abstractions;
using DVL_Sync_FileEventsLogger.Models;

namespace DVL_Sync_FileEventsLogger.Implementations
{
    public sealed class FolderEventsLoggerInConsole : IFolderEventsLogger
    {
        private readonly FolderConfig folderConfig;

        public FolderEventsLoggerInConsole(FolderConfig folderConfig) => this.folderConfig = folderConfig;

        public void Dispose()
        { 

        }

        public void LogOperation<TOperation>(TOperation operation) where TOperation : OperationEvent
        {
            try
            {
                if (folderConfig.IsValid(operation))
                    Console.WriteLine(operation);
            }
            catch(Exception exc)
            {
                Console.WriteLine("Exception when logging operation");
                Console.WriteLine(exc.ToString());
            }
        }
    }
}
