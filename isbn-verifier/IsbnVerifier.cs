public static class IsbnVerifier
{
    public static bool IsValid(string number)
    {
        number = number.Replace("-", "").ToLower();
        if (number.Length != 10) return false;
        if (number.Any(c => c != 'x' && !char.IsDigit(c)) 
            || number[..8].Any(x => x == 'x')) return false;
        int[] numbers = number.Select(c => char.IsDigit(c) ? int.Parse(c.ToString()) : 10).ToArray();
        return numbers.Select((t, i) => t * (10 - i)).Sum() % 11 == 0;
    }
}