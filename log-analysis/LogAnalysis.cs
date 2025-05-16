public static class LogAnalysis 
{
    // TODO: define the 'SubstringAfter()' extension method on the `string` type
    public static string SubstringAfter(this string str, string substr)
    {
        int index = 0;
        index = str.IndexOf(substr) + substr.Length;
        return str.Substring(index);
    }
    // TODO: define the 'SubstringBetween()' extension method on the `string` type
    
    public static string SubstringBetween(this string str, string start, string end)
    {
        int indexStart = str.IndexOf(start) + start.Length;
        int indexEnd = str.IndexOf(end);
        int length = indexEnd - indexStart;
        return str.Substring(indexStart, length);
    }
    // TODO: define the 'Message()' extension method on the `string` type
    public static string Message(this string str)
    {
        return str.SubstringAfter(": ");
    }
    // TODO: define the 'LogLevel()' extension method on the `string` type
    public static string LogLevel(this string str)
    {
        return str.SubstringBetween("[", "]");
    }
}   