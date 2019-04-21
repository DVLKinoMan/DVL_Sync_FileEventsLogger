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

    public class OperationEvent
    {
        public EventType EventType { get; set; }
        protected string FileName
        {
            get => Path.GetFileName(FilePath);
        }
        protected FileType FileType
        {
            get => Directory.Exists(FilePath) ? FileType.Directory : FileType.File;
        }
        public DateTime RaisedTime { get; set; }
        public string FilePath { get; set; }
         
        public override string ToString() => $"EventType: {EventType} FileName: {FileName} FileType: {FileType} RaisedTime: {RaisedTime} FilePath: {FilePath}";
    }

    public class DefaultOperationEvent : OperationEvent
    {

    }
}
