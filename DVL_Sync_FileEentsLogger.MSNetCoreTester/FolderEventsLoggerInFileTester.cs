using DVL_Sync_FileEventsLogger.Implementations;
using DVL_Sync_FileEventsLogger.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Extensions;
using System.IO;
using System.Text;

namespace DVL_Sync_FileEentsLogger.MSNetCoreTester
{
    [TestClass]
    public class FolderEventsLoggerInFileTester
    {
        private readonly FolderConfig folderConfig;
        //private readonly FolderEventsLoggerInFile folderEventsLoggerInFile;

        public FolderEventsLoggerInFileTester() => this.folderConfig = new FolderConfig { FolderPath = "D:\\DVL_Sync_WatcherTestingFile2" };
        //this.folderEventsLoggerInFile = new FolderEventsLoggerInFile(this.folderConfig, streamWriter);

        //private Stream CreateFileStream() => new FileStream($"{folderConfig.FolderPath}/{Constants.TextLogFileName}",
        //    FileMode.OpenOrCreate);

        private StreamWriter CreateStreamWriter(MemoryStream stream) =>
            SetAttributeHiddenAndAutoflush(new StreamWriter(stream));

        private StreamWriter SetAttributeHiddenAndAutoflush(StreamWriter streamWriter) =>
            streamWriter.SetAttributeToHidden().SetAutoFlush();

        [TestMethod]
        public void CreateOperationEventLoggedCorrectly()
        {
            using(var stream = new MemoryStream())
            using (var eventsLogger = new FolderEventsLoggerInFile(this.folderConfig, CreateStreamWriter(stream)))
            {
                var createOp = new CreateOperationEvent()
                    {FilePath = "D:\\David\\txtFile", RaisedTime = DateTime.Today};
                eventsLogger.LogOperation(createOp);

                string actual = Encoding.UTF8.GetString(stream.ToArray());
                Assert.AreEqual(createOp, actual);
            }
        }
    }
}
