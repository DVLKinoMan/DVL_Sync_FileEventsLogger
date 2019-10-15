using DVL_Sync_FileEventsLogger.Models;
using SystemEventArgs = System.EventArgs;

namespace DVL_Sync_FileEventsLogger.Abstractions
{
    public interface IOperationEventFactory
    {
        //OperationEvent CreateOperationEvent<EventArgs>(EventArgs args, EventType eventType)
        //    //where Operation : OperationEvent
        //    where EventArgs : SystemEventArgs;

        CreateOperationEvent GetCreateOperationEvent<TEventArgs>(TEventArgs args)
            //where Operation : OperationEvent
            where TEventArgs : SystemEventArgs;

        EditOperationEvent GetEditOperationEvent<TEventArgs>(TEventArgs args)
            //where Operation : OperationEvent
            where TEventArgs : SystemEventArgs;

        DeleteOperationEvent GetDeleteOperationEvent<TEventArgs>(TEventArgs args)
            //where Operation : OperationEvent
            where TEventArgs : SystemEventArgs;

        RenameOperationEvent GetRenameOperationEvent<TEventArgs>(TEventArgs args)
            //where Operation : OperationEvent
            where TEventArgs : SystemEventArgs;
    }
}
