using System.Numerics;

public static class BafflingBirthdays
{
    // returns the days passed to the start of a month and the month from the day of the year
    private static (int, int) month(int day) => day switch
    {
        <= 31 => (0, 1),
        <= 59 => (31, 2),
        <= 90 => (59, 3),
        <= 120 => (90, 4),
        <= 151 => (120, 5),
        <= 181 => (151, 6),
        <= 212 => (181, 7),
        <= 243 => (212, 8),
        <= 273 => (243, 9),
        <= 304 => (273, 10),
        <= 334 => (304, 11),
        <= 365 => (334, 12),
        _ => throw new ArgumentOutOfRangeException(new string("Only positive integers <= 365 allowed, no leap years in this exercise"))
    };
    public static DateOnly[] RandomBirthdates(int numberOfBirthdays)
    {
        Random random = new Random();
        DateOnly[] birthdates = new DateOnly[numberOfBirthdays];
        for (int i = 0; i < numberOfBirthdays; i++)
        {
            int year;
            do
            {
                year = random.Next(0, 2026);
            } while (DateTime.IsLeapYear(year));
                
            int dayOfYear = random.Next(1, 366);
            (int day, int month) = BafflingBirthdays.month(dayOfYear);
            day = dayOfYear - day;
            birthdates[i] = new DateOnly(year, month, day);
        }
        return birthdates;
    }

    public static bool SharedBirthday(DateOnly[] birthdays)
    {
        const int defaultYear = 1;
        LinkedList<DateOnly> days = new LinkedList<DateOnly>();
        foreach (var birthday in birthdays)
        {
            if (days.All(x => x.CompareTo(new DateOnly(defaultYear, birthday.Month, birthday.Day)) != 0))
            {
                days.AddLast(new DateOnly(defaultYear, birthday.Month, birthday.Day));
            }
            else
            {
                return true;
            }
        }
        return false;
    }

    private static BigInteger factorial(int n)
    {
        BigInteger result = 1;
        for (int i = 1; i <= n; i++)
        {
            result *= i;
        }

        return result;
    }
    public static double EstimatedProbabilityOfSharedBirthday(int numberOfBirthdays)
    {

        double vNr = (double) BigInteger.Divide(factorial(365), factorial(365 - numberOfBirthdays));
        double vT = Math.Pow(365, numberOfBirthdays);
        double pA = vNr / vT;
        return (1 - pA) * 100;
    }
}
