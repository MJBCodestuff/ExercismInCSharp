public class CryptoSquareTests
{
    [Fact]
    public void Normalization_test()
    {
        Assert.Equal("ifmanwasmeanttostayonthegroundgodwouldhavegivenusroots", CryptoSquare.NormalizedPlaintext("If man was meant to stay on the ground, god would have given us roots."));
    }
    
    [Fact]
    public void Segment_test()
    {
        List<string> segments = new List<string>();
        segments.Add("ifmanwas");
        segments.Add("meanttos");
        segments.Add("tayonthe");
        segments.Add("groundgo");
        segments.Add("dwouldha");
        segments.Add("vegivenu");
        segments.Add("sroots  ");
        Assert.Equal(segments,CryptoSquare.PlaintextSegments("If man was meant to stay on the ground, god would have given us roots."));
    }
    
    [Fact]
    public void Encoded_test()
    {
        Assert.Equal("imtgdvsfearwermayoogoanouuiontnnlvtwttddesaohghn sseoau ", CryptoSquare.Encoded("If man was meant to stay on the ground, god would have given us roots."));
    }
    
    [Fact]
    public void Empty_plaintext_results_in_an_empty_ciphertext()
    {
        Assert.Equal("", CryptoSquare.Ciphertext(""));
    }
    

    [Fact]
    public void Normalization_results_in_empty_plaintext()
    {
        Assert.Equal("", CryptoSquare.Ciphertext("... --- ..."));
    }

    [Fact]
    public void Lowercase()
    {
        Assert.Equal("a", CryptoSquare.Ciphertext("A"));
    }

    [Fact]
    public void Remove_spaces()
    {
        Assert.Equal("b", CryptoSquare.Ciphertext("  b "));
    }

    [Fact]
    public void Remove_punctuation()
    {
        Assert.Equal("1", CryptoSquare.Ciphertext("@1,%!"));
    }

    [Fact]
    public void Nine_character_plaintext_results_in_3_chunks_of_3_characters()
    {
        Assert.Equal("tsf hiu isn", CryptoSquare.Ciphertext("This is fun!"));
    }

    [Fact]
    public void Eight_character_plaintext_results_in_3_chunks_the_last_one_with_a_trailing_space()
    {
        Assert.Equal("clu hlt io ", CryptoSquare.Ciphertext("Chill out."));
    }

    [Fact]
    public void Fifty_four_character_plaintext_results_in_7_chunks_the_last_two_with_trailing_spaces()
    {
        Assert.Equal("imtgdvs fearwer mayoogo anouuio ntnnlvt wttddes aohghn  sseoau ", CryptoSquare.Ciphertext("If man was meant to stay on the ground, god would have given us roots."));
    }
}
