using System.IO;

namespace System.Extensions
{
    public static class SystemExts
    {
        public static void SetAttributeToHidden(this FileInfo fileInfo) => fileInfo.Attributes |= FileAttributes.Hidden;

        public static StreamWriter SetAttributeToHidden(this StreamWriter streamWriter)
        {
            new FileInfo(streamWriter.FullPath()).SetAttributeToHidden();
            return streamWriter;
        }

        public static StreamWriter SetAutoFlush(this StreamWriter streamWriter, bool autoFlush = true)
        {
            streamWriter.AutoFlush = autoFlush;
            return streamWriter;
        }

        public static string FullPath(this StreamWriter streamWriter) => ((FileStream) streamWriter.BaseStream).Name;

        public static bool IsNullOrEmpty(this string str) => string.IsNullOrEmpty(str);
    }
}
