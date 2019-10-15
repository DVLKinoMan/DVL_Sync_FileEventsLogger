using System.IO;

namespace DVL_Sync_FileEventsLogger.Models
{
    public sealed class RenameOperationEvent : OperationEvent
    {
        public string OldFilePath { get; set; }
        public string OldFileName  => Path.GetFileName(OldFilePath);

        public override EventType EventType { get => EventType.Rename;
            set { } }

        public static explicit operator FakeRenameOperationEvent(RenameOperationEvent op) => new FakeRenameOperationEvent
        {
            EventType = op.EventType,
            FilePath = op.FilePath,
            FileType = op.FileType,
            RaisedTime = op.RaisedTime,
            OldFilePath = op.OldFilePath
        };

        public override string ToString() => $"{base.ToString()} OldFileName: {OldFileName} OldFilePath: {OldFilePath}";
    }
}
