using DVL_Sync_FileEventsLogger.Domain.Abstractions;
using DVL_Sync_FileEventsLogger.Domain.Models;
using System;
using System.IO;

namespace DVL_Sync_FileEventsLogger.Domain.Implementations
{
    public sealed class OperationEventFactory : IOperationEventFactory
    {
        public OperationEvent CreateOperationEvent<EventArgs>(EventArgs args, EventType eventType)
            //where Operation : OperationEvent
            where EventArgs : System.EventArgs
        {
            switch (args)
            {
                case FileSystemEventArgs fileSystemArgs:
                    return CreateOperationEventFromFileSystemEventArgs(fileSystemArgs, eventType);
                default:
                    throw new NotImplementedException("EventArgs Not Implemented");
            }
        }

        public static OperationEvent CreateOperationEventFromFileSystemEventArgs(FileSystemEventArgs args, EventType eventType)
        {
            void SetOperationEvent(OperationEvent op)
            {
                op.RaisedTime = DateTime.Now;
                op.FilePath = args.FullPath;
            };

            OperationEvent operation;
            if (args is RenamedEventArgs renamedEventArgs)
                operation = new RenameOperationEvent
                {
                    OldFilePath = renamedEventArgs.OldFullPath
                };
            else
            {
                switch (eventType)
                {
                    case EventType.Create:
                        operation = new CreateOperationEvent();
                        break;
                    case EventType.Edit:
                        operation = new EditOperationEvent();
                        break;
                    case EventType.Delete:
                        operation = new DeleteOperationEvent();
                        break;
                    case EventType.Rename:
                        throw new ArgumentException("eventType equals EventType.Rename and args is not RenamedEventArgs");
                    default:
                        throw new ArgumentException("EventType is not Supported");
                }
            }

            SetOperationEvent(operation);
            return operation;
        }
    }
}
