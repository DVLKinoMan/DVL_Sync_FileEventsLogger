using System.IO;
using System.Linq;

namespace System.Extensions
{
    public static class SystemExts
    {
        public static void SetAttributeToHidden(this string path) => 
            path.AddFileAttribute(FileAttributes.Hidden);

        public static void AddFileAttribute(this string path, FileAttributes attribute) => 
            File.SetAttributes(path, File.GetAttributes(path) | attribute);

        public static void RemoveFileAttribute(this string path, FileAttributes attribute) =>
             File.SetAttributes(path, File.GetAttributes(path) & ~attribute);

        public static StreamWriter SetAttributeToHidden(this StreamWriter streamWriter)
        {
            streamWriter.FullPath().SetAttributeToHidden();
            return streamWriter;
        }

        public static StreamWriter SetAutoFlush(this StreamWriter streamWriter, bool autoFlush = true)
        {
            streamWriter.AutoFlush = autoFlush;
            return streamWriter;
        }

        /// <summary>
        /// Works if StreamWriter's BaseStream can be casted to FileStream
        /// </summary>
        /// <param name="streamWriter"></param>
        /// <returns></returns>
        public static string FullPath(this StreamWriter streamWriter) => ((FileStream) streamWriter.BaseStream).Name;

        public static bool IsNullOrEmpty(this string str) => string.IsNullOrEmpty(str);

        public static string Format(this DateTime dateTime, string format, params (string,string)[] withReplacedValues)
        {
            string result = dateTime.ToString(format);

            foreach (var (item1, item2) in withReplacedValues)
                result = result.Replace(item1, item2);

            return result;
        }

        public static string GetDirectoryPath(this string fullPath)
        {
            int len = Path.GetFileName(fullPath).Length;
            if (len == 0)
                return fullPath;

            return fullPath.Remove(fullPath.Length - len, len);
        }

        public static string SubtractPath(this string fullPath, string exclusion)
        {
            if (exclusion == null)
                return fullPath;
            exclusion = exclusion.ToLower();
            string oldFullPath = fullPath;
            fullPath = fullPath.ToLower();
            if (fullPath.IndexOf(exclusion) != 0)
                return fullPath;

            string res = oldFullPath.Remove(0, exclusion.Length);

            return string.Concat(res.SkipWhile(ch => ch == '\\'));
        }

        public static string GetCustomString(this DateTime dateTime) =>/* dateTime.Format($"MM/dd/yyyy hI1 mmI2 sI3 tt", ("/", "-"), ("I1", "h"), ("I2", "min"), ("I3", "s"));*/
             dateTime.Format($"MM/dd/yyyy", ("/", "-"));

        public static DateTime GetCustomDateTime(this string dateTimeString)
        {
            var arr = dateTimeString.Split(' ');

            var dateArr = arr[0].Split('-');
            int month = int.Parse(dateArr[0]);
            int day = int.Parse(dateArr[1]);
            int year = int.Parse(dateArr[2]);

            //int hour = int.Parse(arr[1].Replace("h", ""));
            //int min = int.Parse(arr[2].Replace("min", ""));
            //int sec = int.Parse(arr[3].Replace("s", ""));

            //return new DateTime(year, month, day, arr[4] == "PM" && hour < 12 ? hour + 12 : hour, min, sec);

            return new DateTime(year, month, day);
        }

    }
}
