public class RunLengthEncodingTests
{
    [Fact]
    public void Run_length_encode_a_string_empty_string()
    {
        Assert.Equal("", RunLengthEncoding.Encode(""));
    }

    [Fact]
    public void Run_length_encode_a_string_single_characters_only_are_encoded_without_count()
    {
        Assert.Equal("XYZ", RunLengthEncoding.Encode("XYZ"));
    }

    [Fact]
    public void Run_length_encode_a_string_string_with_no_single_characters()
    {
        Assert.Equal("2A3B4C", RunLengthEncoding.Encode("AABBBCCCC"));
    }

    [Fact]
    public void Run_length_encode_a_string_single_characters_mixed_with_repeated_characters()
    {
        Assert.Equal("12WB12W3B24WB", RunLengthEncoding.Encode("WWWWWWWWWWWWBWWWWWWWWWWWWBBBWWWWWWWWWWWWWWWWWWWWWWWWB"));
    }

    [Fact]
    public void Run_length_encode_a_string_multiple_whitespace_mixed_in_string()
    {
        Assert.Equal("2 hs2q q2w2 ", RunLengthEncoding.Encode("  hsqq qww  "));
    }

    [Fact]
    public void Run_length_encode_a_string_lowercase_characters()
    {
        Assert.Equal("2a3b4c", RunLengthEncoding.Encode("aabbbcccc"));
    }

    [Fact]
    public void Run_length_decode_a_string_empty_string()
    {
        Assert.Equal("", RunLengthEncoding.Decode(""));
    }

    [Fact]
    public void Run_length_decode_a_string_single_characters_only()
    {
        Assert.Equal("XYZ", RunLengthEncoding.Decode("XYZ"));
    }

    [Fact]
    public void Run_length_decode_a_string_string_with_no_single_characters()
    {
        Assert.Equal("AABBBCCCC", RunLengthEncoding.Decode("2A3B4C"));
    }

    [Fact]
    public void Run_length_decode_a_string_single_characters_with_repeated_characters()
    {
        Assert.Equal("WWWWWWWWWWWWBWWWWWWWWWWWWBBBWWWWWWWWWWWWWWWWWWWWWWWWB", RunLengthEncoding.Decode("12WB12W3B24WB"));
    }

    [Fact]
    public void Run_length_decode_a_string_multiple_whitespace_mixed_in_string()
    {
        Assert.Equal("  hsqq qww  ", RunLengthEncoding.Decode("2 hs2q q2w2 "));
    }

    [Fact]
    public void Run_length_decode_a_string_lowercase_string()
    {
        Assert.Equal("aabbbcccc", RunLengthEncoding.Decode("2a3b4c"));
    }

    [Fact]
    public void Encode_and_then_decode_encode_followed_by_decode_gives_original_string()
    {
        Assert.Equal("zzz ZZ  zZ", RunLengthEncoding.Decode(RunLengthEncoding.Encode("zzz ZZ  zZ")));
    }
}
