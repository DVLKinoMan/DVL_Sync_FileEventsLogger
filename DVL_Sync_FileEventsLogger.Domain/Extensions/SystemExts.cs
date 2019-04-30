using System.IO;

namespace DVL_Sync_FileEventsLogger.Domain.Extensions
{
    internal static class SystemExts
    {
        internal static void SetAttributeToHidden(this FileInfo fileInfo)
        {
            fileInfo.Attributes |= FileAttributes.Hidden;
        }

        internal static StreamWriter SetAttributeToHidden(this StreamWriter streamWriter)
        {
            new FileInfo(streamWriter.FullPath()).SetAttributeToHidden();
            return streamWriter;
        }

        internal static StreamWriter SetAutoFlush(this StreamWriter streamWriter, bool autoFlush = true)
        {
            streamWriter.AutoFlush = autoFlush;
            return streamWriter;
        }

        internal static string FullPath(this StreamWriter streamWriter) => ((FileStream) streamWriter.BaseStream).Name;
    }
}
