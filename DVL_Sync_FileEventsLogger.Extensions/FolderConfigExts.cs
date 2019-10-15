//using DVL_Sync_FileEventsLogger.Domain.Implementations;

using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using DVL_Sync_FileEventsLogger.Models;

//using System.Linq;

namespace DVL_Sync_FileEventsLogger.Extensions
{
    public static class FolderConfigExts
    {

        public static FolderConfig GetFolderConfig(this string path)
        {
            using var r = new StreamReader(path);
            string json = r.ReadToEnd();
            return JsonConvert.DeserializeObject<FolderConfig>(json);
        }

#nullable enable
        public static IEnumerable<FolderConfig> GetFolderConfigs(this string path)
        {
            if (!File.Exists(path))
            {
                var directory = Directory.CreateDirectory(Path.GetDirectoryName(path));
                directory.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
                //Path.GetPathRoot(Environment.SystemDirectory);
                //using (File.Create(path))
                //{
                //    File.SetAttributes(path, File.GetAttributes(path) | FileAttributes.Hidden);
                //}
                File.Create(path).Dispose();
            }

            using var r = new StreamReader(path);
            string json = r.ReadToEnd();
            return JsonConvert.DeserializeObject<IEnumerable<FolderConfig>>(json);
        }
#nullable disable

        //public static bool IsValid(this FolderConfig folderConfig, OperationEvent operation)
        //{
        //    FileInfo flInfo = new FileInfo(operation.FilePath);
        //    if (!folderConfig.WatchHiddenFiles && flInfo.Attributes.HasFlag(FileAttributes.Hidden))
        //        return false;

        //    string txtPath = Path.GetFullPath($"{folderConfig.FolderPath}/{Constants.TextLogFileName}");
        //    string jsonPath = Path.GetFullPath($"{folderConfig.FolderPath}/{Constants.JsonLogFileName}");

        //    //Todo: Maybe It is not watcher is not configured to log at all
        //    if (!folderConfig.WatchLogFiles &&
        //        (string.Equals(operation.FilePath, txtPath) ||
        //         string.Equals(operation.FilePath, jsonPath)))
        //        return false;

        //    if (folderConfig.FilteredFiles != null && folderConfig.FilteredFiles.Contains(operation.FilePath))
        //        return false;

        //    return true;
        //}
    }
}
