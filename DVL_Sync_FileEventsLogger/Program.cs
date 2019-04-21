using System.ServiceProcess;

namespace DVL_Sync_FileEventsLogger
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {

#if DEBUG
            var service = new EventsLoggerService();
            service.OnDebug();
#else
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new EventsLoggerService(), 
            };
            ServiceBase.Run(ServicesToRun);
#endif
        }
    }
}
