using System;
using System.IO;

namespace DVL_Sync_FileEventsLogger.Domain.Models
{
    public enum EventType
    {
        Create,
        Edit,
        Delete,
        Rename
    }

    public enum FileType
    {
        File,
        Directory,
    }

    public abstract class OperationEvent
    {
        public abstract EventType EventType { get; }

        public string FileName => Path.GetFileName(FilePath);

        public FileType FileType  => Directory.Exists(FilePath) ? FileType.Directory : FileType.File;

        public DateTime RaisedTime { get; set; }
        public string FilePath { get; set; }

        public override string ToString() =>
            $"EventType: {EventType} FileName: {FileName} FileType: {FileType} RaisedTime: {RaisedTime} FilePath: {FilePath}";
    }

    //public sealed class DefaultOperationEvent : OperationEvent
    //{

    //}

    public sealed class CreateOperationEvent : OperationEvent
    {
        public override EventType EventType => EventType.Create;
    }

    public sealed class EditOperationEvent : OperationEvent
    {
        public override EventType EventType => EventType.Edit;
    }

    public sealed class DeleteOperationEvent : OperationEvent
    {
        public override EventType EventType => EventType.Delete;
    }
}
