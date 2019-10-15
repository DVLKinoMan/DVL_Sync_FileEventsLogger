using System;
using DVL_Sync_FileEventsLogger.Models;

namespace DVL_Sync_FileEventsLogger.Abstractions
{
    public interface IFolderEventsLogger : IDisposable
    {
        void LogOperation<TOperation>(TOperation operation) where TOperation : OperationEvent;
    }
}
