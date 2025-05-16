public static class SumOfMultiples
{
    public static int Sum(IEnumerable<int> multiples, int max)
        => (from nr in Enumerable.Range(0, max) where multiples.Any(x => x != 0 && nr % x == 0) select nr).Sum();
}