using System;

namespace DVL_Sync_FileEventsLogger.Domain.Abstractions
{
    public interface IFolderEventsHandler
    {
        void OnChanged(object sender, EventArgs e);
        void OnCreated(object sender, EventArgs e);
        void OnDeleted(object sender, EventArgs e);
        void OnRenamed(object sender, EventArgs e);
    }
}
