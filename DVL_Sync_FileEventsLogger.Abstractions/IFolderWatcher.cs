using System;

namespace DVL_Sync_FileEventsLogger.Abstractions
{
    public interface IFolderWatcher : IDisposable
    {
        void StartWatching();
    }
}
