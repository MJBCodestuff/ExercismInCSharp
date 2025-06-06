public static class Proverb
{
    public static string[] Recite(string[] subjects)
    {
        
        if (subjects.Length == 0) return [];
        List<string> proverbs = new List<string>();
        for (int i = 0; i < subjects.Length; i++)
        {
            if (i == subjects.Length - 1)
            {
                proverbs.Add("And all for the want of a " + subjects[0] + ".");
            }
            else
            {
                proverbs.Add("For want of a " + subjects[i] + " the " + subjects[i+1] + " was lost.");
            }
        }
        
        return proverbs.ToArray();
    }
}