public static class PythagoreanTriplet
{
    public static IEnumerable<(int a, int b, int c)> TripletsWithSum(int sum)
    {

        List<(int, int, int)> result = [];
        for (int a = 1; a <= (int)Math.Floor((decimal)sum / 3); a++)
        {
            for (int b = a + 1; b <= (int)Math.Floor((decimal)(sum - a) / 2); b++)
            {
                int c = sum - a - b;
                // checking if no fraction first, any loss of precision is irrelevant
                if (a*a + b*b == c*c)
                {
                    result.Add((a, b, c));

                }
            }
        }
        return result;
    }
}