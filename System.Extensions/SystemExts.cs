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

        public static string Format(this DateTime dateTime, string format, params (string,string)[] withReplacedValues)
        {
            string result = dateTime.ToString(format);

            foreach (var replacedValue in withReplacedValues)
                result = result.Replace(replacedValue.Item1, replacedValue.Item2);

            return result;
        }

        public static string GetDirectoryPath(this string fullPath)
        {
            int len = Path.GetFileName(fullPath).Length;
            if (len == 0)
                return fullPath;

            return fullPath.Remove(fullPath.Length - len, len);
        }

    }
}
