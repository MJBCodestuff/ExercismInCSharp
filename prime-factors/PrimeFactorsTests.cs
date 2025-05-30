public class PrimeFactorsTests
{
    [Fact]
    public void No_factors()
    {
        Assert.Empty(PrimeFactors.Factors(1));
    }

    [Fact]
    public void Prime_number()
    {
        long[] expected = [2];
        Assert.Equal(expected, PrimeFactors.Factors(2));
    }

    [Fact]
    public void Another_prime_number()
    {
        long[] expected = [3];
        Assert.Equal(expected, PrimeFactors.Factors(3));
    }

    [Fact]
    public void Square_of_a_prime()
    {
        long[] expected = [3, 3];
        Assert.Equal(expected, PrimeFactors.Factors(9));
    }

    [Fact]
    public void Product_of_first_prime()
    {
        long[] expected = [2, 2];
        Assert.Equal(expected, PrimeFactors.Factors(4));
    }

    [Fact]
    public void Cube_of_a_prime()
    {
        long[] expected = [2, 2, 2];
        Assert.Equal(expected, PrimeFactors.Factors(8));
    }

    [Fact]
    public void Product_of_second_prime()
    {
        long[] expected = [3, 3, 3];
        Assert.Equal(expected, PrimeFactors.Factors(27));
    }

    [Fact]
    public void Product_of_third_prime()
    {
        long[] expected = [5, 5, 5, 5];
        Assert.Equal(expected, PrimeFactors.Factors(625));
    }

    [Fact]
    public void Product_of_first_and_second_prime()
    {
        long[] expected = [2, 3];
        Assert.Equal(expected, PrimeFactors.Factors(6));
    }

    [Fact]
    public void Product_of_primes_and_non_primes()
    {
        long[] expected = [2, 2, 3];
        Assert.Equal(expected, PrimeFactors.Factors(12));
    }

    [Fact]
    public void Product_of_primes()
    {
        long[] expected = [5, 17, 23, 461];
        Assert.Equal(expected, PrimeFactors.Factors(901255));
    }

    [Fact]
    public void Factors_include_a_large_prime()
    {
        long[] expected = [11, 9539, 894119];
        Assert.Equal(expected, PrimeFactors.Factors(93819012551));
    }
}
