using System.IO;

namespace DVL_Sync_FileEventsLogger.Domain.Abstractions
{
    public interface IFolderEventsHandler
    {
        void OnChanged(object sender, FileSystemEventArgs e);
        void OnCreated(object sender, FileSystemEventArgs e);
        void OnDeleted(object sender, FileSystemEventArgs e);
        void OnRenamed(object sender, RenamedEventArgs e);
    }
}
