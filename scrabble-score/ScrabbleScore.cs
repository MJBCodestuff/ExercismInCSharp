public static class ScrabbleScore
{
    public static int Score(string input)
    {
        Dictionary<char, int> scores = new Dictionary<char, int>();
        foreach (char c in "AEIOULNRST")
        {
            scores.Add(c, 1);
        }
        foreach (char c in "DG")
        {
            scores.Add(c, 2);
        }
        foreach (char c in "BCMP")
        {
            scores.Add(c, 3);
        }
        foreach (char c in "FHVWY")
        {
            scores.Add(c, 4);
        }
        scores.Add('K', 5);
        foreach (char c in "JX")
        {
            scores.Add(c, 8);
        }
        foreach (char c in "QZ")
        {
            scores.Add(c, 10);
        }
        return input.ToUpper().ToCharArray().Select(x => scores[x]).Sum();
    }
}