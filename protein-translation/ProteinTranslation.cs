public static class ProteinTranslation
{
    private static string _strand = null!;

    private static readonly Dictionary<string, string> AminoAcids = new Dictionary<string, string>()
    {
        { "AUG", "Methionine" },
        { "UUU", "Phenylalanine" },
        { "UUC", "Phenylalanine" },
        { "UUA", "Leucine" },
        { "UUG", "Leucine" },
        { "UCU", "Serine" },
        { "UCC", "Serine" },
        { "UCA", "Serine" },
        { "UCG", "Serine" },
        { "UAU", "Tyrosine" },
        { "UAC", "Tyrosine" },
        { "UGU", "Cysteine"},
        { "UGC", "Cysteine" },
        { "UGG", "Tryptophan"}

    };
    
    
    
    public static string[] Proteins(string strand)
    {
        List<string> output = new List<string>();
        _strand = strand;
        string? token = NextToken();
        while (token != null && !(new[] { "UAA", "UAG", "UGA" }.Contains(token)))
        {
            output.Add(AminoAcids[token]);
            token = NextToken();
        }
        return output.ToArray();
    }

    private static string? NextToken()
    {
        string? output = null;
        if (_strand.Length >= 3)
        {
            output = _strand.Substring(0, 3);
            _strand = _strand.Substring(3);
        }
        return output;
    }
}