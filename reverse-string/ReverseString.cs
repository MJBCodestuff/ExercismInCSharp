using System.Text;

public static class ReverseString
{
    public static string Reverse(string input)
    {
        StringBuilder sb = new StringBuilder();
        // counting from one because the last index is ^1
        for (int i = 1; i <= input.Length; i++)
        {
            sb.Append(input[^i]);
        }
        return sb.ToString();
    }
}