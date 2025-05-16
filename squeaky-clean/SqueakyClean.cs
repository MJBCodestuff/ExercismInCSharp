using System.Text;
using System.Text.RegularExpressions;

public static class Identifier
{
    public static string Clean(string identifier)
    {
        StringBuilder sb = new StringBuilder(identifier);
        MatchEvaluator evaluator = new MatchEvaluator(x => x.Value.Substring(1).ToUpper());
        sb.Replace(' ', '_');
        foreach (char c in sb.ToString())
        {
            if (Char.IsControl(c))
            {
                sb.Replace(c.ToString(), "CTRL");
            }

            if (!Char.IsLetter(c) && !(new[]{'_', '-'}.Contains(c)))
            {
                sb.Replace(c.ToString(), "");
            }

            if (Char.IsBetween(c, 'α', 'ω'))
            {
                sb.Replace(c.ToString(), "");
            }
        }

        string solution = sb.ToString();
        solution = Regex.Replace(solution, "-\\p{L}", evaluator, RegexOptions.None);
        return solution;
    }
}
