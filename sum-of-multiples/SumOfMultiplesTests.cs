public class SumOfMultiplesTests
{
    [Fact]
    public void No_multiples_within_limit()
    {
        Assert.Equal(0, SumOfMultiples.Sum([3, 5], 1));
    }

    [Fact]
    public void One_factor_has_multiples_within_limit()
    {
        Assert.Equal(3, SumOfMultiples.Sum([3, 5], 4));
    }

    [Fact]
    public void More_than_one_multiple_within_limit()
    {
        Assert.Equal(9, SumOfMultiples.Sum([3], 7));
    }

    [Fact]
    public void More_than_one_factor_with_multiples_within_limit()
    {
        Assert.Equal(23, SumOfMultiples.Sum([3, 5], 10));
    }

    [Fact]
    public void Each_multiple_is_only_counted_once()
    {
        Assert.Equal(2318, SumOfMultiples.Sum([3, 5], 100));
    }

    [Fact]
    public void A_much_larger_limit()
    {
        Assert.Equal(233168, SumOfMultiples.Sum([3, 5], 1000));
    }

    [Fact]
    public void Three_factors()
    {
        Assert.Equal(51, SumOfMultiples.Sum([7, 13, 17], 20));
    }

    [Fact]
    public void Factors_not_relatively_prime()
    {
        Assert.Equal(30, SumOfMultiples.Sum([4, 6], 15));
    }

    [Fact]
    public void Some_pairs_of_factors_relatively_prime_and_some_not()
    {
        Assert.Equal(4419, SumOfMultiples.Sum([5, 6, 8], 150));
    }

    [Fact]
    public void One_factor_is_a_multiple_of_another()
    {
        Assert.Equal(275, SumOfMultiples.Sum([5, 25], 51));
    }

    [Fact]
    public void Much_larger_factors()
    {
        Assert.Equal(2203160, SumOfMultiples.Sum([43, 47], 10000));
    }

    [Fact]
    public void All_numbers_are_multiples_of_1()
    {
        Assert.Equal(4950, SumOfMultiples.Sum([1], 100));
    }

    [Fact]
    public void No_factors_means_an_empty_sum()
    {
        Assert.Equal(0, SumOfMultiples.Sum([], 10000));
    }

    [Fact]
    public void The_only_multiple_of_0_is_0()
    {
        Assert.Equal(0, SumOfMultiples.Sum([0], 1));
    }

    [Fact]
    public void The_factor_0_does_not_affect_the_sum_of_multiples_of_other_factors()
    {
        Assert.Equal(3, SumOfMultiples.Sum([3, 0], 4));
    }

    [Fact]
    public void Solutions_using_include_exclude_must_extend_to_cardinality_greater_than_3()
    {
        Assert.Equal(39614537, SumOfMultiples.Sum([2, 3, 5, 7, 11], 10000));
    }
}
