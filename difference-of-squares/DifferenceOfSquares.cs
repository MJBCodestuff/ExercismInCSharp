public static class DifferenceOfSquares
{
    public static int CalculateSquareOfSum(int max)
    {
        IEnumerable<int> numbers = Enumerable.Range(1, max);
        int sum = numbers.Aggregate(0, (current, next) => current + next);
        return sum * sum;
    }

    public static int CalculateSumOfSquares(int max)
    {
        IEnumerable<int> numbers = Enumerable.Range(1, max);
        int sumofSquares = numbers.Aggregate(0, (current, next) => current + (next * next));
        return sumofSquares;
    }

    public static int CalculateDifferenceOfSquares(int max) => CalculateSquareOfSum(max) - CalculateSumOfSquares(max);
}


