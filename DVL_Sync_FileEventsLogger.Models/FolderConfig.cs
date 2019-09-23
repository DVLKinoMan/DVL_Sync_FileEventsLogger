using System.Collections.Generic;
using System.IO;
using System.Linq;
using SystemNotifyFilters = System.IO.NotifyFilters;
using System.Extensions;

namespace DVL_Sync_FileEventsLogger.Models
{
    public class FolderConfig
    {
        public string FolderPath { get; set; }
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
        public IEnumerable<string> FilteredFiles { get; set; }

        public bool IsValid(OperationEvent operation, string textLogFileName = null, string jsonLogFileName = null)
        {
            var flInfo = new FileInfo(operation.FilePath);
            if (!this.WatchHiddenFiles && flInfo.Attributes.HasFlag(FileAttributes.Hidden) && operation.EventType != EventType.Delete)
                return false;

            //Todo: Maybe It is not watcher is not configured to log at all
            //if (!this.WatchLogFiles)
            //{
            if (!textLogFileName.IsNullOrEmpty())
            {
                //string txtPath = Path.GetFullPath($"{this.FolderPath}/{textLogFileName}");
                //if (IsLogFile(operation.FilePath, txtPath))
                if (IsLogFileWithLogName(operation.FilePath, textLogFileName))
                    return false;
            }

            if (!jsonLogFileName.IsNullOrEmpty())
            {
                //string jsonPath = Path.GetFullPath($"{this.FolderPath}/{jsonLogFileName}");
                //if (IsLogFile(operation.FilePath, jsonPath))
                    if (IsLogFileWithLogName(operation.FilePath, jsonLogFileName))
                        return false;
            }
            //}

            if (this.FilteredFiles != null && this.FilteredFiles.Contains(operation.FilePath))
                return false;

            return true;
        }

        public bool IsLogFileWithLogName(string fullPath, string logName)
        {
            string logFilePath = Path.GetFullPath($"{this.FolderPath}/{logName}");
            return IsLogFile(fullPath, logFilePath);
        }

        public static bool IsLogFile(string fullPath, string logFilePath)
        {
            string name = Path.GetFileName(fullPath);
            int index = name.LastIndexOf("- ");
            if (index < 0 || index + 2 >= fullPath.Length)
                return false;

            var path = $"{fullPath.GetDirectoryPath()}{name.Substring(index + 2)}";
            return string.Equals(path, logFilePath);
        }
    }
}
