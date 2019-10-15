using DVL_Sync_FileEventsLogger.Implementations;
using DVL_Sync_FileEventsLogger.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Extensions;
using System.IO;

namespace DVL_Sync_FileEventsLogger.MSNetCoreTester
{
    [TestClass]
    public class FolderConfigTester
    {

        #region WatchHiddenFiles

        [TestMethod]
        public void WatchHiddenFilesTester1()
        {
            string path = $"{Guid.NewGuid()}.xml";
            var stream = File.Create(path);

            try
            {
                var folderConfig = new FolderConfig
                {
                    FolderPath = stream.Name.GetDirectoryPath(),
                    //WatchLogFiles = true,
                    WatchHiddenFiles = true
                };

                var op = new CreateOperationEvent
                {
                    FilePath = stream.Name,
                    RaisedTime = new DateTime(2017,11,27)
                };

                Assert.AreEqual(true, folderConfig.IsValid(op));
            }
            finally
            {
                stream.Close();
                File.Delete(path);
            }
        }

        [TestMethod]
        public void WatchHiddenFilesTester2()
        {
            string path = $"{Guid.NewGuid()}.xml";
            var stream = File.Create(path);

            try
            {
                new FileInfo(stream.Name).Attributes |= FileAttributes.Hidden;

                var folderConfig = new FolderConfig
                {
                    FolderPath = stream.Name.GetDirectoryPath(),
                    //WatchLogFiles = true,
                    WatchHiddenFiles = true
                };

                var op = new CreateOperationEvent
                {
                    FilePath = stream.Name,
                    RaisedTime = new DateTime(2017, 11, 27)
                };

                Assert.AreEqual(true, folderConfig.IsValid(op));

            }
            finally
            {
                stream.Close();
                File.Delete(path);
            }
        }

        [TestMethod]
        public void WatchHiddenFilesTester3()
        {
            string path = $"{Guid.NewGuid()}.xml";
            var stream = File.Create(path);

            try
            {
                new FileInfo(stream.Name).Attributes |= FileAttributes.Hidden;

                var folderConfig = new FolderConfig
                {
                    FolderPath = stream.Name.GetDirectoryPath(),
                    //WatchLogFiles = true,
                    WatchHiddenFiles = false
                };

                var op = new CreateOperationEvent
                {
                    FilePath = stream.Name,
                    RaisedTime = new DateTime(2017, 11, 27)
                };

                Assert.AreEqual(false, folderConfig.IsValid(op));
            }
            finally
            {
                stream.Close();
                File.Delete(path);
            }
        }

        #endregion

        //#region WatchLogFiles

        //[TestMethod]
        //public void WatchLogFilesTester1()
        //{
        //    string path = $"{Guid.NewGuid()}.xml";
        //    var stream = File.Create(path);

        //    var folderConfig = new FolderConfig
        //    {
        //        FolderPath = stream.Name,
        //        WatchLogFiles = true
        //    };

        //    var op = new CreateOperationEvent
        //    {
        //        FilePath = path,
        //        RaisedTime = DateTime.Now
        //    };

        //    Assert.AreEqual(true, folderConfig.IsValid(op));

        //    stream.Close();
        //    File.Delete(path);
        //}

        //[TestMethod]
        //public void WatchLogFilesTester2()
        //{
        //    string path = $"{Guid.NewGuid()}.xml";
        //    var stream = File.Create(path);

        //    var folderConfig = new FolderConfig
        //    {
        //        FolderPath = stream.Name,
        //        WatchLogFiles = false
        //    };

        //    var op = new CreateOperationEvent
        //    {
        //        FilePath = path,
        //        RaisedTime = DateTime.Now
        //    };

        //    Assert.AreEqual(true, folderConfig.IsValid(op));

        //    stream.Close();
        //    File.Delete(path);
        //}

        //#endregion

        #region JsonLogFileName

        //[TestMethod]
        //public void JsonLogFileNameTester1()
        //{
        //    string path = $"{Guid.NewGuid()}.xml";
        //    var stream = File.Create(path);

        //    try
        //    {
        //        var folderConfig = new FolderConfig
        //        {
        //            FolderPath = stream.Name.GetDirectoryPath(),
        //            WatchHiddenFiles = false
        //        };

        //        var op = new CreateOperationEvent
        //        {
        //            FilePath = stream.Name,
        //            RaisedTime = DateTime.Now
        //        };

        //        Assert.AreEqual(
        //            !FolderConfig.IsLogFile(op.FilePath,
        //                Path.GetFullPath($"{folderConfig.FolderPath}/{Constants.JsonLogFileName}")),
        //            folderConfig.IsValid(op, jsonLogFileName: Constants.JsonLogFileName));
        //    }
        //    finally
        //    {
        //        stream.Close();
        //        File.Delete(path);
        //    }
        //}

        [TestMethod]
        public void JsonLogFileNameTester2()
        {
            string path = $"SomeDateTime - {Constants.JsonLogFileName}";
            var stream = File.Create(path);

            try
            {
                var folderConfig = new FolderConfig
                {
                    FolderPath = stream.Name.GetDirectoryPath(),
                    WatchHiddenFiles = false
                };

                var op = new CreateOperationEvent
                {
                    FilePath = stream.Name,
                    RaisedTime = new DateTime(2017, 11, 27)
                };

                Assert.AreEqual(
                    !FolderConfig.IsLogFile(op.FilePath,
                        Path.GetFullPath($"{folderConfig.FolderPath}/{Constants.JsonLogFileName}")),
                    folderConfig.IsValid(op, jsonLogFileName: Constants.JsonLogFileName));
            }
            finally
            {
                stream.Close();
                File.Delete(path);
            }
        }

        [TestMethod]
        public void JsonLogFileNameTester3()
        {
            string path = $"SomeDateTime - {Constants.JsonLogFileName}";
            var stream = File.Create(path);

            try
            {
                var folderConfig = new FolderConfig
                {
                    FolderPath = stream.Name.GetDirectoryPath(),
                    WatchHiddenFiles = false
                };

                var op = new CreateOperationEvent
                {
                    FilePath = stream.Name,
                    RaisedTime = new DateTime(2017, 11, 27)
                };

                Assert.AreEqual(true, folderConfig.IsValid(op));
            }
            finally
            {
                stream.Close();
                File.Delete(path);
            }
        }

        #endregion

        #region TextLogFileName

        [TestMethod]
        public void TextLogFileNameTester1()
        {
            string path = $"SomeDateTime - {Constants.TextLogFileName}";
            var stream = File.Create(path);

            try
            {
                var folderConfig = new FolderConfig
                {
                    FolderPath = stream.Name.GetDirectoryPath(),
                    WatchHiddenFiles = false
                };

                var op = new CreateOperationEvent
                {
                    FilePath = stream.Name,
                    RaisedTime = new DateTime(2017, 11, 27)
                };

                Assert.AreEqual(
                    !FolderConfig.IsLogFile(op.FilePath,
                        Path.GetFullPath($"{folderConfig.FolderPath}/{Constants.TextLogFileName}")),
                    folderConfig.IsValid(op, textLogFileName: Constants.TextLogFileName));
            }
            finally
            {
                stream.Close();
                File.Delete(path);
            }
        }

        [TestMethod]
        public void TextLogFileNameTester2()
        {
            string path = $"SomeDateTime - {Constants.TextLogFileName}";
            var stream = File.Create(path);

            try
            {
                var folderConfig = new FolderConfig
                {
                    FolderPath = stream.Name.GetDirectoryPath(),
                    WatchHiddenFiles = false
                };

                var op = new CreateOperationEvent
                {
                    FilePath = stream.Name,
                    RaisedTime = new DateTime(2017, 11, 27)
                };

                Assert.AreEqual(true, folderConfig.IsValid(op));
            }
            finally
            {
                stream.Close();
                File.Delete(path);
            }
        }

        #endregion

        #region FilteredFiles

        [TestMethod]
        public void FilteredFilesTester1()
        {
            string path = $"SomeTempFile.txt";
            var stream = File.Create(path);

            try
            {
                var folderConfig = new FolderConfig
                {
                    FolderPath = stream.Name.GetDirectoryPath(),
                    WatchHiddenFiles = false,
                    FilteredFiles = new List<string>(){ stream.Name}
                };

                var op = new CreateOperationEvent
                {
                    FilePath = stream.Name,
                    RaisedTime = new DateTime(2017, 11, 27)
                };

                Assert.AreEqual(false, folderConfig.IsValid(op));
            }
            finally
            {
                stream.Close();
                File.Delete(path);
            }
        }

        [TestMethod]
        public void FilteredFilesTester2()
        {
            string path = $"SomeTempFile.txt";
            var stream = File.Create(path);

            try
            {
                var folderConfig = new FolderConfig
                {
                    FolderPath = stream.Name.GetDirectoryPath(),
                    WatchHiddenFiles = false,
                    FilteredFiles = new List<string>() { $"{stream.Name.GetDirectoryPath()}SomeTempFile2.txt" }
                };

                var op = new CreateOperationEvent
                {
                    FilePath = stream.Name,
                    RaisedTime = new DateTime(2017, 11, 27)
                };

                Assert.AreEqual(true, folderConfig.IsValid(op));
            }
            finally
            {
                stream.Close();
                File.Delete(path);
            }
        }

        #endregion
    }
}
