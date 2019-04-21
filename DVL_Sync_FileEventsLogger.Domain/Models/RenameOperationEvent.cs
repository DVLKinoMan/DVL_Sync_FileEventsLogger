using System.IO;

namespace DVL_Sync_FileEventsLogger.Domain.Models
{
    public class RenameOperationEvent : OperationEvent
    {
        public RenameOperationEvent()
        {
            EventType = EventType.Rename;
        }

        public string OldFilePath { get; set; }
        public string OldFileName
        {
            get => Path.GetFileName(OldFilePath);
        }

        public override string ToString() => $"{base.ToString()} OldFileName: {OldFileName} OldFilePath: {OldFilePath}";
    }
}
