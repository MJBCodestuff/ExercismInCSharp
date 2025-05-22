public static class Pangram
{
    public static bool IsPangram(string input)
    {
        bool[] contained = new bool[26];
        foreach (var c in input.ToLower().Where(c => char.IsLetter(c)))
        {
            contained[c - 'a'] = true;
        }
        return contained.All(x => x);
    }
}
