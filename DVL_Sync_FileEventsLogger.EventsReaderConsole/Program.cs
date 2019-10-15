using DVL_Sync_FileEventsLogger.Abstractions;
using DVL_Sync_FileEventsLogger.Implementations;
using DVL_Sync_FileEventsLogger.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DVL_Sync_FileEventsLogger.Extensions;

namespace DVL_Sync_FileEventsLogger.EventsReaderConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            const string eventsInstructions = "Type Events that Occured in Directory{0}Events are: Delete, Rename, Create, Edit{0}";
            const string navigationInstructions = "Use Navigate to Navigate in Folders (Navigate to 'somefilepath' (Case Nonsensitive)){0}";
            const string example = "Example: Navigate to 'D:\\DVL_Sync_WatcherTestingFile'//By Default{0}Create newTextDocument.txt";

            Console.WriteLine(eventsInstructions + navigationInstructions + example, Environment.NewLine);
            string currentDirectory = "D:\\DVL_Sync_WatcherTestingFile";
            var events = new[] { "create", "edit",  "delete","rename" };
            var fileTypes = new[] { "file", "directory" };

            var operationEventsList = new List<OperationEvent>();

            IFolderEventsLoggerFactory folderEventsLoggerFactory =
                new FolderEventsLoggerFactory();

            while (true)
            {
                var command = Console.ReadLine()?.Trim().Split(' ');
                if (!(command?.Length >= 2)) 
                    continue;
                string fCom = command[0].ToLower();
                string sCom = command[1].ToLower();
                if (fCom == "navigate" &&  sCom == "to")
                {
                    string path = string.Join(' ', command.Skip(2));
                    currentDirectory = path;
                }
                else if (events.Contains(fCom))
                {
                    OperationEvent opEvent;
                    var filePaths = string.Join(' ', command.Skip(1)).Split(",");
                    bool isRenameEvent = false;
                    switch (fCom)
                    {
                        case "create":
                            opEvent =new CreateOperationEvent();
                            break;
                        case "edit":
                            opEvent = new EditOperationEvent();
                            break;
                        case "delete":
                            opEvent = new DeleteOperationEvent();
                            break;
                        case "rename":
                            opEvent = new RenameOperationEvent() { OldFilePath = Path.Combine(currentDirectory, filePaths[0]), FilePath = Path.Combine(currentDirectory, filePaths[1]) };
                            isRenameEvent = true; 
                            break;
                        default: throw new NotImplementedException($"{fCom} not implemented");
                    }
                    opEvent.RaisedTime = DateTime.Now;
                    if (!isRenameEvent)
                        opEvent.FilePath = Path.Combine(currentDirectory, filePaths[0]);

                    var folderConfig = new FolderConfig { FolderPath = currentDirectory, WatchHiddenFiles = true };
                    var loggerTypes = new [] { LoggerType.JsonFile };
                    var logger =
                        new MultipleFolderEventsLogger(loggerTypes.GetFolderEventsLoggers(folderEventsLoggerFactory, folderConfig)
                            .ToArray());
                    logger.LogOperation(opEvent);

                    operationEventsList.Add(opEvent);
                }
            }
        }
    }
}
