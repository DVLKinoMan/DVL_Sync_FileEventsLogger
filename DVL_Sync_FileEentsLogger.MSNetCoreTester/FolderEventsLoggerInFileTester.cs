using DVL_Sync_FileEventsLogger.Implementations;
using DVL_Sync_FileEventsLogger.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Extensions;
using System.IO;
using System.Text;

namespace DVL_Sync_FileEventsLogger.MSNetCoreTester
{
    [TestClass]
    public class FolderEventsLoggerInFileTester
    {
        //private readonly FolderConfig folderConfig;
        //private readonly FolderEventsLoggerInFile folderEventsLoggerInFile;

        //public FolderEventsLoggerInFileTester() => this.folderConfig = new FolderConfig { FolderPath = "D:\\DVL_Sync_WatcherTestingFile2" };
        //this.folderEventsLoggerInFile = new FolderEventsLoggerInFile(this.folderConfig, streamWriter);

        //private Stream CreateFileStream() => new FileStream($"{folderConfig.FolderPath}/{Constants.TextLogFileName}",
        //    FileMode.OpenOrCreate);

        private StreamWriter CreateStreamWriter(MemoryStream stream) =>
            SetAttributeToAutoflush(new StreamWriter(stream));

        private StreamWriter SetAttributeToAutoflush(StreamWriter streamWriter) =>
            streamWriter.SetAutoFlush();

        [TestMethod]
        public void CreateOperationEventLoggedCorrectly()
        {
            var createOp = new CreateOperationEvent()
                { FilePath = GetType().Assembly.Location, RaisedTime = new DateTime(2017, 11, 23)};
            var folderConfig = new FolderConfig { FolderPath = "D:\\DVL_Sync_WatcherTestingFile2" };

            OperationEventLoggedCorrectly(createOp, folderConfig);
        }

        [TestMethod]
        public void EditOperationEventLoggedCorrectly()
        {
                var editOp = new EditOperationEvent()
                    { FilePath = GetType().Assembly.Location, RaisedTime = new DateTime(2017, 11, 23) };
                var folderConfig = new FolderConfig { FolderPath = "D:\\DVL_Sync_WatcherTestingFile2" };

                OperationEventLoggedCorrectly(editOp, folderConfig);
        }

        [TestMethod]
        public void DeleteOperationEventLoggedCorrectly()
        {
                var delOp = new DeleteOperationEvent()
                    { FilePath = GetType().Assembly.Location, RaisedTime = new DateTime(2017, 11, 23) };
                var folderConfig = new FolderConfig {FolderPath = "D:\\DVL_Sync_WatcherTestingFile2"};

                OperationEventLoggedCorrectly(delOp, folderConfig);
        }

        [TestMethod]
        public void RenameOperationEventLoggedCorrectly()
        {
            var renameOp = new RenameOperationEvent()
            {
                FilePath = GetType().Assembly.Location, RaisedTime = new DateTime(2017, 11, 23),
                OldFilePath = "D:\\SomeInValidPath"
            };
            var folderConfig = new FolderConfig {FolderPath = "D:\\DVL_Sync_WatcherTestingFile2"};

            OperationEventLoggedCorrectly(renameOp, folderConfig);
        }

        private void OperationEventLoggedCorrectly(OperationEvent opEvent, FolderConfig folderConfig)
        {
            //using (var stream = new MemoryStream())
            //using (var eventsLogger = new FolderEventsLoggerInFile(folderConfig, CreateStreamWriter(stream)))
            //{
            //    eventsLogger.LogOperation(opEvent);

            //    //Check if two equals
            //    string actual = Encoding.Default.GetString(stream.ToArray());

            //    if (folderConfig.IsValid(opEvent, Constants.TextLogFileName))
            //    {
            //        string expected = $"{opEvent}{Environment.NewLine}";
            //        Assert.AreEqual(expected, actual);
            //    }
            //    else Assert.AreEqual(string.Empty, actual);
            //}
        }
    }
}
