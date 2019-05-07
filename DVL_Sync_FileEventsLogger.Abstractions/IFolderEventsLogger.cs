using System;
using DVL_Sync_FileEventsLogger.Models;

namespace DVL_Sync_FileEventsLogger.Abstractions
{
    public interface IFolderEventsLogger : IDisposable
    {
        void LogOperation<Operation>(Operation operation) where Operation : OperationEvent;
    }
}
