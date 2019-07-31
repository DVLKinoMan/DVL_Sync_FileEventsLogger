using Newtonsoft.Json;
using System;
using System.IO;

namespace DVL_Sync_FileEventsLogger.Models
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

    [JsonConverter(typeof(OperationEventConverter))]
    public abstract class OperationEvent
    {
        public abstract EventType EventType { get; set; }

        public string FileName => Path.GetFileName(FilePath);

        public FileType FileType  => Directory.Exists(FilePath) ? FileType.Directory : FileType.File;

        public DateTime RaisedTime { get; set; }
        public string FilePath { get; set; }

        public static explicit operator FakeOperationEvent(OperationEvent op) => new FakeOperationEvent
        {
            EventType = op.EventType,
            FilePath = op.FilePath,
            FileType = op.FileType,
            RaisedTime = op.RaisedTime
        };

        public override string ToString() =>
            $"EventType: {EventType} FileName: {FileName} FileType: {FileType} RaisedTime: {RaisedTime} FilePath: {FilePath}";
    }

    //public sealed class DefaultOperationEvent : OperationEvent
    //{

    //}

    public sealed class CreateOperationEvent : OperationEvent
    {
        public override EventType EventType { get { return EventType.Create; } set { } }
    }

    public sealed class EditOperationEvent : OperationEvent
    {
        public override EventType EventType { get { return EventType.Edit; } set { } }
    }

    public sealed class DeleteOperationEvent : OperationEvent
    {
        public override EventType EventType { get { return EventType.Delete; } set { } }
    }
}
