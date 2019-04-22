using DVL_Sync_FileEventsLogger.Domain.Abstractions;
using DVL_Sync_FileEventsLogger.Domain.Models;
using System.IO;

namespace DVL_Sync_FileEventsLogger.Domain.Implementations
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
