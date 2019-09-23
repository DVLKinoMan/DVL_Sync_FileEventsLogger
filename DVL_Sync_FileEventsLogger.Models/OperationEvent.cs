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

        public FileType FileType { get; set; }

        public DateTime RaisedTime { get; set; }
        public string FilePath { get
            {
                return _filePath;
            }
            set
            {
                _filePath = value.ToLower();
                FileType = Directory.Exists(FilePath) ? FileType.Directory : (File.Exists(FilePath) ? FileType.File : DetermineFileType(FilePath));
            }
        }
        private string _filePath;

        private FileType DetermineFileType(string filePath)
        {
            string filename = Path.GetFileName(filePath);
            if (filename.Length >= 4 && filename[filename.Length - 4] == '.')
                return FileType.File;
            else return FileType.Directory;
        }

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
