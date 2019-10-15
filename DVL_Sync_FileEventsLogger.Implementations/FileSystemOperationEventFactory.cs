using System;
using System.IO;
using DVL_Sync_FileEventsLogger.Abstractions;
using DVL_Sync_FileEventsLogger.Models;
using SystemEventArgs = System.EventArgs;

namespace DVL_Sync_FileEventsLogger.Implementations
{
    public sealed class FileSystemOperationEventFactory : IOperationEventFactory
    {
        public CreateOperationEvent GetCreateOperationEvent<TEventArgs>(TEventArgs args)
            where TEventArgs : SystemEventArgs => SetOperationEvent(args, new CreateOperationEvent());

        public EditOperationEvent GetEditOperationEvent<TEventArgs>(TEventArgs args)
            where TEventArgs : SystemEventArgs => SetOperationEvent(args, new EditOperationEvent());

        public DeleteOperationEvent GetDeleteOperationEvent<TEventArgs>(TEventArgs args)
            where TEventArgs : SystemEventArgs => SetOperationEvent(args, new DeleteOperationEvent());

        public RenameOperationEvent GetRenameOperationEvent<TEventArgs>(TEventArgs args)
            where TEventArgs : SystemEventArgs => SetOperationEvent(args,
            SetOldFilePathToRenameOperationEvent(args, new RenameOperationEvent()));

        private static TEvent SetOperationEvent<TEvent>(SystemEventArgs args, TEvent op)
            where TEvent : OperationEvent =>
            args switch
            {
                FileSystemEventArgs fileSystemArgs => (TEvent)op.WithRaisedTime(DateTime.Now).WithFilePath(fileSystemArgs.FullPath),
                _ => throw new NotImplementedException("EventArgs Not Implemented")
            };


        private static RenameOperationEvent SetOldFilePathToRenameOperationEvent(SystemEventArgs args, RenameOperationEvent op) =>
            args switch
            {
                RenamedEventArgs renamedEventArgs => op.WithOldFilePath(renamedEventArgs.OldFullPath),
                _ => throw new ArgumentException("args is not RenamedEventArgs")
            };

    }
}
