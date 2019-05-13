using System.IO;

namespace DVL_Sync_FileEventsLogger.Models
{
    public sealed class RenameOperationEvent : OperationEvent
    {
        public string OldFilePath { get; set; }
        public string OldFileName  => Path.GetFileName(OldFilePath);

        public override EventType EventType => EventType.Rename;

        public override string ToString() => $"{base.ToString()} OldFileName: {OldFileName} OldFilePath: {OldFilePath}";
    }
}
