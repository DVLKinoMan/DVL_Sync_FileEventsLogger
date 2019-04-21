using DVL_Sync_FileEventsLogger.Domain.Abstractions;
using System;
using System.IO;
using DVL_Sync_FileEventsLogger.Domain.Models;

namespace DVL_Sync_FileEventsLogger.Domain.Implementations
{
    public class FolderEventsHandlerViaLogging : IFolderEventsHandler
    {
        private IFolderEventsLogger logger;

        public FolderEventsHandlerViaLogging(IFolderEventsLogger logger)
        {
            this.logger = logger;
        }

        //public IFolderEventsHandler WithFolderEventsLogger(IFolderEventsLogger logger)
        //{
        //    this.logger = logger;
        //    return this;
        //}

        public void OnChanged(object sender, FileSystemEventArgs e) =>
            logger.LogOperation(
                new DefaultOperationEvent
                {
                    EventType = EventType.Edit,
                    RaisedTime = DateTime.Now,
                    FilePath = e.FullPath
                });

        public void OnCreated(object sender, FileSystemEventArgs e) =>
            logger.LogOperation(
                new DefaultOperationEvent
                {
                    EventType = EventType.Create,
                    RaisedTime = DateTime.Now,
                    FilePath = e.FullPath
                });

        public void OnDeleted(object sender, FileSystemEventArgs e) =>
            logger.LogOperation(
                new DefaultOperationEvent
                {
                    EventType = EventType.Delete,
                    RaisedTime = DateTime.Now,
                    FilePath = e.FullPath
                });

        public void OnRenamed(object sender, RenamedEventArgs e) =>
            logger.LogOperation(
                new RenameOperationEvent
                {
                    EventType = EventType.Rename,
                    RaisedTime = DateTime.Now,
                    FilePath = e.FullPath,
                    OldFilePath = e.OldFullPath
                });
    }
}
