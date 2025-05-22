using System.Text;

using Xunit.Internal;

public static class Transpose
{
    public static string String(string input)
    {
        if (string.IsNullOrEmpty(input)) return "";
        
        string[] rows =  input.Split('\n');
        int[] length =  rows.Select(row => row.Length).ToArray();
        int maxLength = length.Max();
        
        string[] columns = new string[maxLength];
        for (int i = 0; i < maxLength; i++) // column by column
        {
            StringBuilder sb = new StringBuilder();
            for (var j = 0; j < rows.Length; j++) // row by row
            {
                // if we still have characters
                if (rows[j].Length > i) sb.Append(rows[j][i]);
                // if we are currently in a column that includes more letters in a later row
                // ... also good to know c# can do ranges. Good stuff.
                else if (i < (length[j..]).Max()) sb.Append(' ');
                
            }
            columns[i] = sb.ToString();
        }

        // turning the array into a string seperated by newlines 
        string result = columns.Aggregate((x, y) => $"{x}\n{y}");
        return result;

    }
}