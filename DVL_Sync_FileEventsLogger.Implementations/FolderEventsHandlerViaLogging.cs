//using DVL_Sync_FileEventsLogger.Domain.Models;
using System;
using DVL_Sync_FileEventsLogger.Abstractions;

namespace DVL_Sync_FileEventsLogger.Implementations
{
    public sealed class FolderEventsHandlerViaLogging : IFolderEventsHandler
    {
        private readonly IFolderEventsLogger logger;
        private readonly IOperationEventFactory operationEventFactory;

        public FolderEventsHandlerViaLogging(IOperationEventFactory operationEventFactory,
            IFolderEventsLogger logger) =>
            (this.operationEventFactory, this.logger) = (operationEventFactory, logger);

        public void Dispose() => logger.Dispose();

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
