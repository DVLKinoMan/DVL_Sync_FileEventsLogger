using DVL_Sync_FileEventsLogger.Abstractions;
using DVL_Sync_FileEventsLogger.Models;

namespace DVL_Sync_FileEventsLogger.Implementations
{
    public sealed class MultipleFolderEventsLogger : IFolderEventsLogger
    {
        private readonly IFolderEventsLogger[] loggers;

        public MultipleFolderEventsLogger(params IFolderEventsLogger[] loggers) => this.loggers = loggers;

        public void Dispose()
        {
            foreach (var logger in loggers)
                logger.Dispose();
        }

        public void LogOperation<TOperation>(TOperation operation) where TOperation : OperationEvent
        {
            foreach (var logger in loggers)
                logger.LogOperation(operation);
        }
    }
}
