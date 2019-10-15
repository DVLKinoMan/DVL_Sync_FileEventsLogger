using System.Collections.Generic;
using System.IO;
using System.Linq;
using SystemNotifyFilters = System.IO.NotifyFilters;
using System.Extensions;

namespace DVL_Sync_FileEventsLogger.Models
{

#nullable enable
    public class FolderConfig
    {
        public string? FolderPath { get; set; }
        public bool IncludeSubDirectories { get; set; } = true;

        public SystemNotifyFilters NotifyFilters { get; set; } = SystemNotifyFilters.LastAccess
                                                                 | SystemNotifyFilters.LastWrite
                                                                 | SystemNotifyFilters.FileName
                                                                 | SystemNotifyFilters.DirectoryName;

        //public bool WatchLogFiles { get; set; } = false;
        public bool WatchHiddenFiles { get; set; } = false;

        /// <summary>
        /// File Paths, which Events would not be Handled
        /// </summary>
        public IEnumerable<string>? FilteredFiles { get; set; }

        public bool IsValid(OperationEvent operation, string? textLogFileName = null, string? jsonLogFileName = null)
        {
            var flInfo = new FileInfo(operation.FilePath);
            if (!this.WatchHiddenFiles && flInfo.Attributes.HasFlag(FileAttributes.Hidden) &&
                operation.EventType != EventType.Delete)
                return false;

            //Todo: Maybe It is not watcher is not configured to log at all
            if (!textLogFileName.IsNullOrEmpty() && IsLogFileWithLogName(operation.FilePath, textLogFileName))
                return false;

            if (!jsonLogFileName.IsNullOrEmpty() && IsLogFileWithLogName(operation.FilePath, jsonLogFileName))
                return false;

            return this.FilteredFiles == null || !this.FilteredFiles.Contains(operation.FilePath);

            //if (File.Exists(operation.FilePath))
            //{
            //    var currAtrributes = File.GetAttributes(operation.FilePath);
            //    if (currAtrributes.HasFlag(FileAttributes.ReadOnly))
            //    {
            //        operation.FilePath.RemoveFileAttribute(FileAttributes.ReadOnly);
            //        return false;
            //    }
            //}
        }

        public bool IsLogFileWithLogName(string fullPath, string? logName)
        {
            string logFilePath = Path.GetFullPath($"{this.FolderPath}/{logName}");
            return IsLogFile(fullPath, logFilePath);
        }

        public static bool IsLogFile(string fullPath, string? logFilePath)
        {
            string name = Path.GetFileName(fullPath);
            int index = name.LastIndexOf("- ");
            if (index < 0 || index + 2 >= fullPath.Length)
                return false;

            var path = $"{fullPath.GetDirectoryPath()}{name.Substring(index + 2)}";
            return string.Equals(path, logFilePath);
        }
    }
#nullable disable

}
