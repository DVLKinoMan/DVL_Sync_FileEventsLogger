//using DVL_Sync_FileEventsLogger.Domain.Abstractions;
//using DVL_Sync_FileEventsLogger.Domain.Implementations;
//using DVL_Sync_FileEventsLogger.DomainOnWindows.Implementations;

//namespace DVL_Sync_FileEventsLogger.Console
//{
//    public static class Environment
//    {
//        public static readonly string appid = "DVL_Sync_EventLogger";

//        public static readonly IOperationEventFactory operationEventFactory = new OperationEventFactory();

//        public static readonly IFolderEventsLogger logger =
//            new MultipleFolderEventsLogger(new FolderEventsLoggerInWindows10Notifications(appid),
//                new FolderEventsLoggerInConsole());

//        public static readonly IFolderEventsHandler handler =
//            new FolderEventsHandlerViaLogging(operationEventFactory, logger);

//    }
//}
