namespace DVL_Sync_FileEventsLogger.Domain.Models
{
    public class FoldersWatcherConfig
    {
        public string IFolderWatcher { get; set; } = "Default";
        public string FoldersConfigsPath { get; set; } = "C:\\DVL_Sync_FileEventsLogger\\FoldersConfigs.json";
        public string IFolderEventsHandler { get; set; } = "Default";
        public string IOperationEventFactory { get; set; } = "Default";
        public string[] IFolderEventsLogger { get; set; }
        public string AppID { get; set; } = "DVL_Sync_EventLogger";
    }
}
