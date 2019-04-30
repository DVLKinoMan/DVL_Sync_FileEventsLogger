using DVL_Sync_FileEventsLogger.Domain.Abstractions;
using DVL_Sync_FileEventsLogger.Domain.Models;
using System;
using DVL_Sync_FileEventsLogger.Domain.Extensions;

namespace DVL_Sync_FileEventsLogger.Domain.Implementations
{
    public class FolderEventsLoggerInConsole : IFolderEventsLogger
    {
        private readonly FolderConfig folderConfig;

        public FolderEventsLoggerInConsole(FolderConfig folderConfig) => this.folderConfig = folderConfig;

        public void Dispose()
        { 

        }

        public void LogOperation<Operation>(Operation operation) where Operation : OperationEvent
        {
            if (folderConfig.IsValid(operation))
                Console.WriteLine(operation);
        }

        //{
        //    switch (operation)
        //    {
        //        case DefaultOperationEvent op:
        //            break;
        //        case RenameOperationEvent op:
        //            break;
        //    }
        //}
    }
}
