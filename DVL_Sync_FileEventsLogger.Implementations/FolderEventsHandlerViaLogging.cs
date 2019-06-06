//using DVL_Sync_FileEventsLogger.Domain.Models;
using System;
using DVL_Sync_FileEventsLogger.Abstractions;

namespace DVL_Sync_FileEventsLogger.Implementations
{
    public sealed class FolderEventsHandlerViaLogging : IFolderEventsHandler
    {
        private readonly IFolderEventsLogger logger;
        private readonly IOperationEventFactory operationEventFactory;

        public FolderEventsHandlerViaLogging(IOperationEventFactory operationEventFactory, IFolderEventsLogger logger)
        {
            this.operationEventFactory = operationEventFactory;
            this.logger = logger;
        }

        public void Dispose() => logger.Dispose();

        //public IFolderEventsHandler WithFolderEventsLogger(LoggerTypes logger)
        //{
        //    this.logger = logger;
        //    return this;
        //}

        public void OnChanged(object sender, EventArgs e) =>
            logger.LogOperation(operationEventFactory.GetEditOperationEvent(e));

        public void OnCreated(object sender, EventArgs e) =>
            logger.LogOperation(operationEventFactory.GetCreateOperationEvent(e));

        public void OnDeleted(object sender, EventArgs e) =>
            logger.LogOperation(operationEventFactory.GetDeleteOperationEvent(e));

        public void OnRenamed(object sender, EventArgs e) =>
            logger.LogOperation(operationEventFactory.GetRenameOperationEvent(e));
    }
}
