using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DVL_Sync_FileEventsLogger.Abstractions;
using DVL_Sync_FileEventsLogger.Implementations;
using DVL_Sync_FileEventsLogger.Models;
using System.Extensions;

namespace DVL_Sync_FileEventsLogger.Extensions
{
    public static class FoldersWatcherConfigExts
    {
        public static FoldersWatcherConfig GetFoldersWatcherConfig(this string path)
        {
            using (var r = new StreamReader(path))
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
                                    IOperationEventFactory operationEventFactory = new FileSystemOperationEventFactory();

                                    if (config.LoggerTypes == null || config.LoggerTypes.Length == 0)
                                        throw new ArgumentException("config.LoggerTypes");

                                    IFolderEventsLoggerFactory folderEventsLoggerFactory =
                                        new FolderEventsLoggerFactory();

                                    IEnumerable<IFolderEventsHandler> folderEventsHandlers =
                                        foldersConfigs.GetFolderEventsHandlers(config.LoggerTypes,
                                            folderEventsLoggerFactory, operationEventFactory);

                                    IFoldersWatcherFactory foldersWatcherFactory = new
                                        FoldersWatcherFactoryViaFileSystemWatcher();

                                    return foldersWatcherFactory.CreateFoldersWatcher(folderEventsHandlers,
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

        private static IEnumerable<IFolderEventsHandler> GetFolderEventsHandlers(
            this IEnumerable<FolderConfig> foldersConfigs, LoggerType[] loggerTypes,
            IFolderEventsLoggerFactory folderEventsLoggerFactory, IOperationEventFactory operationEventFactory)
        {
            foreach (var folderConfig in foldersConfigs)
            {
                IFolderEventsLogger logger =
                    new MultipleFolderEventsLogger(loggerTypes
                        .GetFolderEventsLoggers(folderEventsLoggerFactory, folderConfig)
                        .ToArray());

                IFolderEventsHandler folderEventsHandler =
                    new FolderEventsHandlerViaLogging(operationEventFactory, logger);

                yield return folderEventsHandler;
            }
        }

        public static IEnumerable<IFolderEventsLogger> GetFolderEventsLoggers(this LoggerType[] loggerTypes,
            IFolderEventsLoggerFactory folderEventsLoggerFactory, FolderConfig folderConfig)
        {
            foreach (var loggerType in loggerTypes)
            {
                if (folderConfig != null && !Directory.Exists(folderConfig.FolderPath))
                    throw new DirectoryNotFoundException($"Directory on Path {folderConfig.FolderPath} Not Found");

                switch (loggerType)
                {
                    case LoggerType.Console:
                        yield return folderEventsLoggerFactory.CreateLoggerInConsole(folderConfig);
                        break;
                    case LoggerType.TextFile:
                        yield return folderEventsLoggerFactory.CreateLoggerInTextFile(folderConfig, 
                            $"{folderConfig.FolderPath}/{DateTime.Now.GetCustomString()} - {Constants.TextLogFileName}");
                        break;
                    case LoggerType.JsonFile:
                        yield return folderEventsLoggerFactory.CreateLoggerInJsonFile(folderConfig,
                                    $"{folderConfig.FolderPath}/{DateTime.Now.GetCustomString()} - {Constants.JsonLogFileName}");
                        break;
                    case LoggerType.Windows10Notification:
                        yield return folderEventsLoggerFactory.CreateLoggerAsWindows10Notification(folderConfig,
                            Constants
                                .ApplicationIDForWindows10);
                        break;
                    default:
                        throw new ArgumentException("loggerType");
                }
            }

            //yield return folderEventsLoggerFactory.CreateFolderEventsLogger(loggerString, folderConfig);
        }

    }
}
