﻿using DVL_Sync_FileEventsLogger.Abstractions;
using DVL_Sync_FileEventsLogger.Models;

namespace DVL_Sync_FileEventsLogger.Implementations
{
    public class MultipleFolderEventsLogger : IFolderEventsLogger
    {
        private readonly IFolderEventsLogger[] loggers;

        public MultipleFolderEventsLogger(params IFolderEventsLogger[] loggers) => this.loggers = loggers;

        public void Dispose()
        {
            foreach (var logger in loggers)
                logger.Dispose();
        }

        public void LogOperation<Operation>(Operation operation) where Operation : OperationEvent
        {
            foreach (var logger in loggers)
                logger.LogOperation(operation);
        }
    }
}