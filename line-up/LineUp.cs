using System.Linq;
public static class LineUp
{
    public static string Format(string name, int number)
    {
        Dictionary<int, string> suffixes = new Dictionary<int, string>()
        {
            { 1, "st" },
            { 2, "nd" },
            { 3, "rd" }
        };
        var suffix = !new int[] { 11, 12, 13 }.Contains(number % 100) ? suffixes.GetValueOrDefault(number % 10, "th") : "th";

        return $"{name}, you are the {number}{suffix} customer we serve today. Thank you!";
    }
}
