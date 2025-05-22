public static class Isogram
{
    public static bool IsIsogram(string word)
    {
        int mask = 0;
        foreach (char c in word.ToLower().Where(c => char.IsLetter(c)))
        {
            if ((mask & (0 | 1 << (c - 'a'))) == 0)
                mask |= 1 << (c - 'a');
            else
                return false;

        }
        return true;
    }
}
