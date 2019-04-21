using DVL_Sync_FileEventsLogger.Domain.Models;

namespace DVL_Sync_FileEventsLogger.Domain.Abstractions
{
    public interface IFolderEventsLogger
    {
        void LogOperation<Operation>(Operation operation) where Operation : OperationEvent;
    }
}
