public class IsbnVerifierTests
{
    [Fact]
    public void Valid_isbn()
    {
        Assert.True(IsbnVerifier.IsValid("3-598-21508-8"));
    }

    [Fact]
    public void Invalid_isbn_check_digit()
    {
        Assert.False(IsbnVerifier.IsValid("3-598-21508-9"));
    }

    [Fact]
    public void Valid_isbn_with_a_check_digit_of_10()
    {
        Assert.True(IsbnVerifier.IsValid("3-598-21507-X"));
    }

    [Fact]
    public void Check_digit_is_a_character_other_than_x()
    {
        Assert.False(IsbnVerifier.IsValid("3-598-21507-A"));
    }

    [Fact]
    public void Invalid_check_digit_in_isbn_is_not_treated_as_zero()
    {
        Assert.False(IsbnVerifier.IsValid("4-598-21507-B"));
    }

    [Fact]
    public void Invalid_character_in_isbn_is_not_treated_as_zero()
    {
        Assert.False(IsbnVerifier.IsValid("3-598-P1581-X"));
    }

    [Fact]
    public void X_is_only_valid_as_a_check_digit()
    {
        Assert.False(IsbnVerifier.IsValid("3-598-2X507-9"));
    }

    [Fact]
    public void Valid_isbn_without_separating_dashes()
    {
        Assert.True(IsbnVerifier.IsValid("3598215088"));
    }

    [Fact]
    public void Isbn_without_separating_dashes_and_x_as_check_digit()
    {
        Assert.True(IsbnVerifier.IsValid("359821507X"));
    }

    [Fact]
    public void Isbn_without_check_digit_and_dashes()
    {
        Assert.False(IsbnVerifier.IsValid("359821507"));
    }

    [Fact]
    public void Too_long_isbn_and_no_dashes()
    {
        Assert.False(IsbnVerifier.IsValid("3598215078X"));
    }

    [Fact]
    public void Too_short_isbn()
    {
        Assert.False(IsbnVerifier.IsValid("00"));
    }

    [Fact]
    public void Isbn_without_check_digit()
    {
        Assert.False(IsbnVerifier.IsValid("3-598-21507"));
    }

    [Fact]
    public void Check_digit_of_x_should_not_be_used_for_0()
    {
        Assert.False(IsbnVerifier.IsValid("3-598-21515-X"));
    }

    [Fact]
    public void Empty_isbn()
    {
        Assert.False(IsbnVerifier.IsValid(""));
    }

    [Fact]
    public void Input_is_9_characters()
    {
        Assert.False(IsbnVerifier.IsValid("134456729"));
    }

    [Fact]
    public void Invalid_characters_are_not_ignored_after_checking_length()
    {
        Assert.False(IsbnVerifier.IsValid("3132P34035"));
    }

    [Fact]
    public void Invalid_characters_are_not_ignored_before_checking_length()
    {
        Assert.False(IsbnVerifier.IsValid("3598P215088"));
    }

    [Fact]
    public void Input_is_too_long_but_contains_a_valid_isbn()
    {
        Assert.False(IsbnVerifier.IsValid("98245726788"));
    }
}
