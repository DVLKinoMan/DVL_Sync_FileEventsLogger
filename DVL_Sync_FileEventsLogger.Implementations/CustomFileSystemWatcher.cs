using System.IO;
using DVL_Sync_FileEventsLogger.Abstractions;
using DVL_Sync_FileEventsLogger.Models;

namespace DVL_Sync_FileEventsLogger.Implementations
{
    public class CustomFileSystemWatcher : IFolderWatcher
    {
        private readonly FileSystemWatcher watcher = new FileSystemWatcher();
        private readonly IFolderEventsHandler folderEventsHandler;
        private readonly FolderConfig folderConfig;

        public CustomFileSystemWatcher(IFolderEventsHandler folderEventsHandler, FolderConfig folderConfig)
        {
            this.folderEventsHandler = folderEventsHandler;
            this.folderConfig = folderConfig;
        }

        public void StartWatching()
        {
            SetFolderEventsHandler();
            SetFolderConfig();
            watcher.EnableRaisingEvents = true;
        }

        private void SetFolderEventsHandler()
        {
            watcher.Changed += folderEventsHandler.OnChanged;
            watcher.Created += folderEventsHandler.OnCreated;
            watcher.Deleted += folderEventsHandler.OnDeleted;
            watcher.Renamed += folderEventsHandler.OnRenamed;
        }

        private void SetFolderConfig()
        {
            watcher.Path = folderConfig.FolderPath;
            watcher.NotifyFilter = folderConfig.NotifyFilters;
            watcher.IncludeSubdirectories = folderConfig.IncludeSubDirectories;
        }
    }
}
