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
    class Program
    {
        static void Main(string[] args)
        {
            string eventsInstructions = "Type Events that Occured in Directory{0}Events are: Delete, Rename, Create, Edit{0}";
            string navigationInstructions = "Use Navigate to Navigate in Folders (Navigate to 'somefilepath' (Case Nonsensitive)){0}";
            string example = "Example: Navigate to 'D:\\DVL_Sync_WatcherTestingFile'//By Default{0}Create newTextDocument.txt";

            Console.WriteLine(eventsInstructions + navigationInstructions + example, Environment.NewLine);
            string currentDirecctory = "D:\\DVL_Sync_WatcherTestingFile";
            string[] events = new string[] { "create", "edit",  "delete","rename" };
            string[] fileTypes = new string[] { "file", "directory" };

            var operationEventsList = new List<OperationEvent>();

            IFolderEventsLoggerFactory folderEventsLoggerFactory =
                new FolderEventsLoggerFactory();

            while (true)
            {
                string[] command = Console.ReadLine().Trim().Split(' ');
                if (command.Length >= 2)
                {
                    string fCom = command[0].ToLower();
                    string sCom = command[1].ToLower();
                    if (fCom == "navigate" &&  sCom == "to")
                    {
                        string path = string.Join(' ', command.Skip(2));
                        currentDirecctory = path;
                    }
                    else if (events.Contains(fCom))
                    {
                        OperationEvent opEvent = new CreateOperationEvent();
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
                                opEvent = new RenameOperationEvent() { OldFilePath = Path.Combine(currentDirecctory, filePaths[0]), FilePath = Path.Combine(currentDirecctory, filePaths[1]) };
                                isRenameEvent = true; 
                                break;
                        }
                        opEvent.RaisedTime = DateTime.Now;
                        if (!isRenameEvent)
                            opEvent.FilePath = Path.Combine(currentDirecctory, filePaths[0]);

                        var folderConfig = new FolderConfig { FolderPath = currentDirecctory, WatchHiddenFiles = true };
                        var loggerTypes = new LoggerType[] { LoggerType.JsonFile };
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
}
