using DVL_Sync_FileEventsLogger.Domain.Abstractions;
using DVL_Sync_FileEventsLogger.Domain.Models;

namespace DVL_Sync_FileEventsLogger.Domain.Implementations
{
    public class MultipleLogger : IFolderEventsLogger
    {
        private readonly IFolderEventsLogger logger1;
        private readonly IFolderEventsLogger logger2;

        public MultipleLogger(IFolderEventsLogger logger1, IFolderEventsLogger logger2)
        {
            this.logger1 = logger1;
            this.logger2 = logger2;
        }

        public void LogOperation<Operation>(Operation operation) where Operation : OperationEvent
        {
            logger1.LogOperation(operation);
            logger2.LogOperation(operation);
        }
    }
}
