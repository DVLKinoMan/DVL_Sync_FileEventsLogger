namespace DVL_Sync_FileEventsLogger.Domain.Implementations
{
    public static class Constants
    {
        public static readonly string JsonLogFileName = "JsonLogFile.json";
        public static readonly string TextLogFileName = "LogFile.txt";
    }

    public enum LoggerType
    {
        TextFile,
        Console,
        JsonFile
    }
}
