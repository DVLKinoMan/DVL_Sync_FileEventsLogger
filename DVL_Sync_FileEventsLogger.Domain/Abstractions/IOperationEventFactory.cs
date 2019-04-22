using DVL_Sync_FileEventsLogger.Domain.Models;
using SystemEventArgs = System.EventArgs;

namespace DVL_Sync_FileEventsLogger.Domain.Abstractions
{
    public interface IOperationEventFactory
    {
        OperationEvent CreateOperationEvent<EventArgs>(EventArgs args, EventType eventType)
            //where Operation : OperationEvent
            where EventArgs : SystemEventArgs;
    }
}
