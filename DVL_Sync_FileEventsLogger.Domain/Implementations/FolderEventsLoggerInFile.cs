﻿using DVL_Sync_FileEventsLogger.Domain.Abstractions;
using DVL_Sync_FileEventsLogger.Domain.Extensions;
using DVL_Sync_FileEventsLogger.Domain.Models;
using System.IO;

namespace DVL_Sync_FileEventsLogger.Domain.Implementations
{
    public class FolderEventsLoggerInFile : IFolderEventsLogger
    {
        private readonly StreamWriter streamWriter;
        private readonly FolderConfig folderConfig;

        public FolderEventsLoggerInFile(StreamWriter stream, FolderConfig folderConfig)
        {
            this.streamWriter = stream;
            this.streamWriter.AutoFlush = true;
            this.folderConfig = folderConfig;
        }

        public void LogOperation<Operation>(Operation operation) where Operation : OperationEvent
        {
            if (folderConfig.IsValid(operation))
                streamWriter.WriteLine(operation);
        }

    }
}
