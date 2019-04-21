using DVL_Sync_FileEventsLogger.Domain.Abstractions;
using DVL_Sync_FileEventsLogger.Domain.Models;
using System;

namespace DVL_Sync_FileEventsLogger.Domain.Implementations
{
    public class FolderEventsLoggerInConsole : IFolderEventsLogger
    {
        public void LogOperation<Operation>(Operation operation) where Operation : OperationEvent =>
            Console.WriteLine(operation);

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
