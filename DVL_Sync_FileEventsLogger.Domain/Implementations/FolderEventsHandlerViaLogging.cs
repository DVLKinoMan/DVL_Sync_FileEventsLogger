using DVL_Sync_FileEventsLogger.Domain.Abstractions;
using DVL_Sync_FileEventsLogger.Domain.Models;
using System;

namespace DVL_Sync_FileEventsLogger.Domain.Implementations
{
    public class FolderEventsHandlerViaLogging : IFolderEventsHandler
    {
        private readonly IFolderEventsLogger logger;
        private readonly IOperationEventFactory operationEventFactory;

        public FolderEventsHandlerViaLogging(IOperationEventFactory operationEventFactory, IFolderEventsLogger logger)
        {
            this.operationEventFactory = operationEventFactory;
            this.logger = logger;
        }

        //public IFolderEventsHandler WithFolderEventsLogger(IFolderEventsLogger logger)
        //{
        //    this.logger = logger;
        //    return this;
        //}

        public void OnChanged(object sender, EventArgs e) =>
            logger.LogOperation(operationEventFactory.CreateOperationEvent(e,EventType.Edit));

        public void OnCreated(object sender, EventArgs e) =>
            logger.LogOperation(operationEventFactory.CreateOperationEvent(e,EventType.Create));

        public void OnDeleted(object sender, EventArgs e) =>
            logger.LogOperation(operationEventFactory.CreateOperationEvent(e,EventType.Delete));

        public void OnRenamed(object sender, EventArgs e) =>
            logger.LogOperation(operationEventFactory.CreateOperationEvent(e,EventType.Rename));
    }
}
