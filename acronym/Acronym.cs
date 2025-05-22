using System.Text;

public static class Acronym
{
    private static readonly char[] AllowedWhiteSpaces = [' ', '-'];

    public static string Abbreviate(string phrase)
    {
        StringBuilder result = new StringBuilder();
        phrase = new string(phrase.Where(x => (!char.IsPunctuation(x) || AllowedWhiteSpaces.Contains(x))).ToArray());
        result.Append(phrase[0]);
        for (int i = 1; i < phrase.Length; i++)
        {
            if (AllowedWhiteSpaces.Contains(phrase[i - 1]) && char.IsLetter(phrase[i]))
            {
                result.Append(char.ToUpper(phrase[i]));
            }
        }

        return result.ToString();
    }
}