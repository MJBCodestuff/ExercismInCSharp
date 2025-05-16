public static class Bob
{
    public static string Response(string statement)
    {
        statement = statement.Trim();
        bool silence = statement.Length == 0;
        bool question = statement.EndsWith('?');
        bool allCaps = statement.ToUpper().Equals(statement) && statement.Any(char.IsUpper);
        
        

        if (question && allCaps)
        {
            return "Calm down, I know what I'm doing!";
        }

        if (question)
        {
            return "Sure.";
        }

        if (allCaps)
        {
            return "Whoa, chill out!";
        }

        if (silence)
        {
            return "Fine. Be that way!";
        }

        return "Whatever.";
    }
}