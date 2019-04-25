using DVL_Sync_FileEventsLogger.Domain.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace DVL_Sync_FileEventsLogger.Domain.Extensions
{
    public static class FolderConfigExts
    {

        public static FolderConfig GetFolderConfig(this string path)
        {
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<FolderConfig>(json);
            }
        }

        public static IEnumerable<FolderConfig> GetFolderConfigs(this string path)
        {
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<IEnumerable<FolderConfig>>(json);
            }
        }
    }
}
