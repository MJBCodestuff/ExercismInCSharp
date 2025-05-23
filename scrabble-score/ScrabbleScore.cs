public static class ScrabbleScore
{
    public static int Score(string input)
    {
        Dictionary<string, int> scores = new Dictionary<string, int>();
        

        return input.ToUpper().ToCharArray().Select(x => scores[x]).Sum();
    }
}