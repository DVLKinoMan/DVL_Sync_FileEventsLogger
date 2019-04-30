using DVL_Sync_FileEventsLogger.Domain.Models;
using SystemEventArgs = System.EventArgs;

namespace DVL_Sync_FileEventsLogger.Domain.Abstractions
{
    public interface IOperationEventFactory
    {
        //OperationEvent CreateOperationEvent<EventArgs>(EventArgs args, EventType eventType)
        //    //where Operation : OperationEvent
        //    where EventArgs : SystemEventArgs;

        CreateOperationEvent GetCreateOperationEvent<EventArgs>(EventArgs args)
            //where Operation : OperationEvent
            where EventArgs : SystemEventArgs;

        EditOperationEvent GetEditOperationEvent<EventArgs>(EventArgs args)
            //where Operation : OperationEvent
            where EventArgs : SystemEventArgs;

        DeleteOperationEvent GetDeleteOperationEvent<EventArgs>(EventArgs args)
            //where Operation : OperationEvent
            where EventArgs : SystemEventArgs;

        RenameOperationEvent GetRenameOperationEvent<EventArgs>(EventArgs args)
            //where Operation : OperationEvent
            where EventArgs : SystemEventArgs;
    }
}
