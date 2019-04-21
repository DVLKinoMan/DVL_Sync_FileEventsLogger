using SystemNotifyFilters = System.IO.NotifyFilters;

namespace DVL_Sync_FileEventsLogger.Domain.Models
{
    public class FolderConfig
    {
        public string FolderPath { get; set; }
        public bool IncludeSubDirectories { get; set; } = true;
        public SystemNotifyFilters NotifyFilters { get; set; } = SystemNotifyFilters.LastAccess
                                                            | SystemNotifyFilters.LastWrite
                                                            | SystemNotifyFilters.FileName
                                                            | SystemNotifyFilters.DirectoryName;
    }
}
