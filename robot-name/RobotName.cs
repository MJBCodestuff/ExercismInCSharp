using System.Text;

public class Robot
{
    
    private static List<string> names = [];
    private static readonly Random Rng = new Random();
    private string? _name;
    
    public string Name => _name ?? GenerateName();

    private string GenerateName()
    {
        string result;
        do
        {
            StringBuilder sb = new StringBuilder();
            sb.Append((char)('A' + Rng.Next(26)));
            sb.Append((char)('A' + Rng.Next(26)));
            sb.Append(Rng.Next(10));
            sb.Append(Rng.Next(10));
            sb.Append(Rng.Next(10));
            result = sb.ToString();
        } while (names.Contains(result));
        names.Add(result);
        _name = result;
        return result;
    }
    
    public void Reset()
    {
        if (_name == null)
        {
            GenerateName();
            return;
        }
        names.Remove(_name);
        _name = GenerateName();
        
    }
}