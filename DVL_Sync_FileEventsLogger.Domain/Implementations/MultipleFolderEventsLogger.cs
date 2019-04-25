using DVL_Sync_FileEventsLogger.Domain.Abstractions;
using DVL_Sync_FileEventsLogger.Domain.Models;

namespace DVL_Sync_FileEventsLogger.Domain.Implementations
{
    public class MultipleFolderEventsLogger : IFolderEventsLogger
    {
        private readonly IFolderEventsLogger[] loggers;

        public MultipleFolderEventsLogger(params IFolderEventsLogger[] loggers) => this.loggers = loggers;

        public void LogOperation<Operation>(Operation operation) where Operation : OperationEvent
        {
            foreach (var logger in loggers)
                logger.LogOperation(operation);
        }
    }
}
