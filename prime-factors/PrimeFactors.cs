public static class PrimeFactors
{
    public static long[] Factors(long number)
    {
        List<long> result = [];
        while (number > 1)
        {
            foreach (long factor in GetPrimes())
            {
                if (number % factor != 0) continue;
                result.Add(factor);
                number = number / factor;
                break;
            }
        }

        return result.ToArray();
    }

    private static IEnumerable<long> GetPrimes()
    {
        for (int i = 2; ; i++)
        {
            if (IsPrime(i)) yield return i;
        }
    }
    private static bool IsPrime(long number)
    {
        if (number < 2) return false;
        if (number == 2) return true;
        for (long i = 2; i * i <= number; i++)
        {
            if (number % i == 0) return false;
            
        }

        return true;
    }
}