using System;
using System.Collections.Generic;
using DVL_Sync_FileEventsLogger.Domain.Models;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using DVL_Sync_FileEventsLogger.Domain.Abstractions;
using DVL_Sync_FileEventsLogger.Domain.Implementations;

namespace DVL_Sync_FileEventsLogger.Domain.Extensions
{
    public static class FoldersWatcherConfigExts
    {
        public static FoldersWatcherConfig GetFoldersWatcherConfig(this string path)
        {
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<FoldersWatcherConfig>(json);
            }
        }

        public static IEnumerable<IFolderWatcher> GetFolderWatchers(this FoldersWatcherConfig config)
        {
            switch (config.IFolderWatcher)
            {
                case "Default":
                    if (string.IsNullOrEmpty(config.FoldersConfigsPath))
                        throw new ArgumentException("config.FoldersConfigsPath");

                    IEnumerable<FolderConfig> foldersConfigs = config.FoldersConfigsPath.GetFolderConfigs();

                    switch (config.IFolderEventsHandler)
                    {
                        case "Default":
                            switch (config.IOperationEventFactory)
                            {
                                case "Default":
                                    IOperationEventFactory operationEventFactory = new OperationEventFactory();

                                    if (config.IFolderEventsLogger == null || config.IFolderEventsLogger.Length == 0)
                                        throw new ArgumentException("config.IFolderEventsLogger");


                                    IFolderEventsLogger logger =
                                        new MultipleFolderEventsLogger(config.IFolderEventsLogger
                                            .GetFolderEventsLoggers().ToArray());

                                    IFolderEventsHandler handler =
                                        new FolderEventsHandlerViaLogging(operationEventFactory, logger);

                                    return
                                        new FoldersWatcherFactoryViaFileSystemWatcher().CreateFoldersWatcher(handler,
                                            foldersConfigs);
                                default:
                                    throw new ArgumentException("config.IOperationEventFactory");
                            }
                        default:
                            throw new ArgumentException("config.IFolderEventsHandler");
                    }
                default:
                    throw new ArgumentException("config.IFolderWatcher");
            }

            //string appid = "DVL_Sync_EventLogger";
            //Windows10NotificationsHelper.TryCreateShortcut(appid);
        }

        //private static IEnumerable<IFolderWatcher> GetFolderWatchersImpl(FoldersWatcherConfig config)
        //{

        //}

        public static IEnumerable<IFolderEventsLogger> GetFolderEventsLoggers(this string[] foldereventsLoggers)
        {
            foreach (var loggerString in foldereventsLoggers)
                yield return loggerString.GetFolderEventsLogger();
        }

        public static IFolderEventsLogger GetFolderEventsLogger(this string logger)
        {
            switch (logger)
            {
                case "Console":
                    return new FolderEventsLoggerInConsole();
                case "File":
                    return new FolderEventsLoggerInFile(new StreamWriter("LogFile.txt"));
                default:
                    throw new ArgumentException("logger");
            }
        }
    }
}
