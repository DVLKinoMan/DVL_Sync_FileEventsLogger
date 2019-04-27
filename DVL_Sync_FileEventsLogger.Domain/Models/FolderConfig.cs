using System.Collections.Generic;
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
        public bool WatchLogFiles { get; set; } = false;
        public bool WatchHiddenFiles { get; set; } = false;
        /// <summary>
        /// File Paths, which Events would not be Handled
        /// </summary>
        public IEnumerable<string> FilteredFiles { get; set; }
    }
}
