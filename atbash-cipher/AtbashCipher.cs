using System.Text;

public static class AtbashCipher
{
    private static readonly char[] Alphabet = Enumerable.Range('a', 26).Select(x => (char)x).ToArray();

    public static string Encode(string plainValue)
    {
        StringBuilder result = new StringBuilder();
        int counter = 0;
        foreach (char c in plainValue.ToLower())
        {
            if (char.IsPunctuation(c) || char.IsWhiteSpace(c)) continue;
            if (char.IsNumber(c)) result.Append(c);
            else
            {
                if (counter % 5 != 0 || counter == 0)
                {
                    result.Append(Alphabet[^(c - 'a' + 1)]);
                }
                else
                {
                    result.Append($" {Alphabet[^(c - 'a' + 1)]}");
                }
            }

            counter++;
        }

        return result.ToString();
    }

    public static string Decode(string encodedValue) =>
        new(Encode(encodedValue).Where(x => !char.IsWhiteSpace(x)).ToArray());
}