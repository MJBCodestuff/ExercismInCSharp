using System.Text;

public static class ResistorColorDuo
{
    private static readonly string[] Colours = ["black", "brown", "red", "orange", "yellow", "green", "blue", "violet", "grey", "white"];
    
    public static int Value(string[] colors)
    {
        if (colors.Length == 0) return -1;
        colors = colors.Length > 2 ? colors.Take(2).ToArray() : colors;
        return int.Parse(string.Join("", colors.Select((x => Array.IndexOf(Colours, x)))));
    }
}
