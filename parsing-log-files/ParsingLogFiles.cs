using System.Text.RegularExpressions;

public class LogParser
{
    public bool IsValidLine(string text)
        => Regex.IsMatch(text, @"^\[TRC]|^\[DBG]|^\[INF]|^\[WRN]|^\[ERR]|^\[FTL]");


    public string[] SplitLogLine(string text)
        => Regex.Replace(text, "(<[\\^\\*=-]+>)", ";").Split(";");

    public int CountQuotedPasswords(string lines)
        => (from line in lines.Split("\n")
            where Regex.IsMatch(line, "\".*password.*\"", RegexOptions.IgnoreCase)
            select 1).Sum();

    public string RemoveEndOfLineText(string line)
        => Regex.Replace(line, "(end-of-line\\d*)", "");

    public string[] ListLinesWithPasswords(string[] lines)
        =>
        [
            .. from line in lines
            select Regex.IsMatch(line, "(password\\S+)", RegexOptions.IgnoreCase)
                ? $"{Regex.Match(line, "(password\\S+)", RegexOptions.IgnoreCase)}: {line}"
                : $"--------: {line}"
        ];
}
