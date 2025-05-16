static class LogLine
{
    public static string Message(string logLine)
    {   
        int index = logLine.IndexOf(':');
        return logLine.Substring(index + 1).Trim();
        }

    public static string LogLevel(string logLine)
    {
        int index = logLine.IndexOf(':');
        return logLine.Substring(1, index - 2).Trim().ToLower();
        
    }

    public static string Reformat(string logLine)
    {
        return $"{Message(logLine)} ({LogLevel(logLine)})";
    }
}
