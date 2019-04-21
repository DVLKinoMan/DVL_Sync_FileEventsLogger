using DVL_Sync_FileEventsLogger.Domain.Abstractions;
using DVL_Sync_FileEventsLogger.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DVL_Sync_FileEventsLogger.Domain.Implementations
{
    public class FolderEventsLoggerInWindows10Notifications : IFolderEventsLogger
    {
        public void LogOperation<Operation>(Operation operation) where Operation : OperationEvent
        {
            throw new NotImplementedException();
        }
    }
}
