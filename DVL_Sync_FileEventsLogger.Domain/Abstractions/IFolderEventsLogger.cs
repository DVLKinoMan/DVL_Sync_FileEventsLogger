using System;
using DVL_Sync_FileEventsLogger.Domain.Models;

namespace DVL_Sync_FileEventsLogger.Domain.Abstractions
{
    public interface IFolderEventsLogger : IDisposable
    {
        void LogOperation<Operation>(Operation operation) where Operation : OperationEvent;
    }
}
