static class SavingsAccount
{
    public static float InterestRate(decimal balance)
    {
        switch (balance)
        {
            case < 0: return 3.213f;
            case < 1000: return 0.5f;
            case < 5000: return 1.621f;
            default: return 2.475f;
            
        }
    }

    public static decimal Interest(decimal balance)
    {
        return balance * (decimal)InterestRate(balance) / 100;
    }

    public static decimal AnnualBalanceUpdate(decimal balance)
    {
        return balance + Interest(balance);
    }

    public static int YearsBeforeDesiredBalance(decimal balance, decimal targetBalance)
    {
        int counter = 0;
        while (balance < targetBalance)
        {
            counter++;
            balance = AnnualBalanceUpdate(balance);
        }
        return counter;
    }
}
