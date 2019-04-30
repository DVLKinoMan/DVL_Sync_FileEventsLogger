using DVL_Sync_FileEventsLogger.Domain.Abstractions;
using DVL_Sync_FileEventsLogger.Domain.Models;
using System;
using System.IO;

using SystemEventArgs = System.EventArgs;

namespace DVL_Sync_FileEventsLogger.Domain.Implementations
{
    public sealed class FileSystemOperationEventFactory : IOperationEventFactory
    {
        public CreateOperationEvent GetCreateOperationEvent<EventArgs>(EventArgs args) where EventArgs : SystemEventArgs => SetOperationEvent(args, new CreateOperationEvent());

        public EditOperationEvent GetEditOperationEvent<EventArgs>(EventArgs args) where EventArgs : SystemEventArgs => SetOperationEvent(args, new EditOperationEvent());

        public DeleteOperationEvent GetDeleteOperationEvent<EventArgs>(EventArgs args) where EventArgs : SystemEventArgs => SetOperationEvent(args, new DeleteOperationEvent());

        public RenameOperationEvent GetRenameOperationEvent<EventArgs>(EventArgs args)
            where EventArgs : SystemEventArgs => SetOperationEvent(args,
            SetOldFilePathToRenameOperationEvent(args, new RenameOperationEvent()));

        private Event SetOperationEvent<Event>(SystemEventArgs args, Event op) where Event : OperationEvent
        {
            switch (args)
            {
                case FileSystemEventArgs fileSystemArgs:
                    op.RaisedTime = DateTime.Now;
                    op.FilePath = fileSystemArgs.FullPath;

                    return op;
                default:
                    throw new NotImplementedException("EventArgs Not Implemented");
            }
        }

        private RenameOperationEvent SetOldFilePathToRenameOperationEvent(SystemEventArgs args, RenameOperationEvent op)
        {
            if (args is RenamedEventArgs renamedEventArgs)
                op.OldFilePath = renamedEventArgs.OldFullPath;
            else
                throw new ArgumentException("args is not RenamedEventArgs");

            return op;
        }

        //public OperationEvent CreateOperationEvent<EventArgs>(EventArgs args, EventType eventType)
        //    //where Operation : OperationEvent
        //    where EventArgs : System.EventArgs
        //{
        //    switch (args)
        //    {
        //        case FileSystemEventArgs fileSystemArgs:
        //            return CreateOperationEventFromFileSystemEventArgs(fileSystemArgs, eventType);
        //        default:
        //            throw new NotImplementedException("EventArgs Not Implemented");
        //    }
        //}

        //public static OperationEvent CreateOperationEventFromFileSystemEventArgs(FileSystemEventArgs args, EventType eventType)
        //{
        //    void SetOperationEvent(OperationEvent op)
        //    {
        //        op.RaisedTime = DateTime.Now;
        //        op.FilePath = args.FullPath;
        //    };

        //    OperationEvent operation;
        //    if (args is RenamedEventArgs renamedEventArgs)
        //        operation = new RenameOperationEvent
        //        {
        //            OldFilePath = renamedEventArgs.OldFullPath
        //        };
        //    else
        //    {
        //        switch (eventType)
        //        {
        //            case EventType.Create:
        //                operation = new CreateOperationEvent();
        //                break;
        //            case EventType.Edit:
        //                operation = new EditOperationEvent();
        //                break;
        //            case EventType.Delete:
        //                operation = new DeleteOperationEvent();
        //                break;
        //            case EventType.Rename:
        //                throw new ArgumentException("eventType equals EventType.Rename and args is not RenamedEventArgs");
        //            default:
        //                throw new ArgumentException("EventType is not Supported");
        //        }
        //    }

        //    SetOperationEvent(operation);
        //    return operation;
        //}

    }
}
