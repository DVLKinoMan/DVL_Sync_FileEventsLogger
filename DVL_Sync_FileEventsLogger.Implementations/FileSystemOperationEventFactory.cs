﻿using System;
using System.IO;
using DVL_Sync_FileEventsLogger.Abstractions;
using DVL_Sync_FileEventsLogger.Models;
using SystemEventArgs = System.EventArgs;

namespace DVL_Sync_FileEventsLogger.Implementations
{
    public sealed class FileSystemOperationEventFactory : IOperationEventFactory
    {
        public CreateOperationEvent GetCreateOperationEvent<TEventArgs>(TEventArgs args) where TEventArgs : SystemEventArgs => SetOperationEvent(args, new CreateOperationEvent());

        public EditOperationEvent GetEditOperationEvent<TEventArgs>(TEventArgs args) where TEventArgs : SystemEventArgs => SetOperationEvent(args, new EditOperationEvent());

        public DeleteOperationEvent GetDeleteOperationEvent<TEventArgs>(TEventArgs args) where TEventArgs : SystemEventArgs => SetOperationEvent(args, new DeleteOperationEvent());

        public RenameOperationEvent GetRenameOperationEvent<TEventArgs>(TEventArgs args)
            where TEventArgs : SystemEventArgs => SetOperationEvent(args,
            SetOldFilePathToRenameOperationEvent(args, new RenameOperationEvent()));

        private static TEvent SetOperationEvent<TEvent>(SystemEventArgs args, TEvent op) where TEvent : OperationEvent
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

        private static RenameOperationEvent SetOldFilePathToRenameOperationEvent(SystemEventArgs args, RenameOperationEvent op)
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
