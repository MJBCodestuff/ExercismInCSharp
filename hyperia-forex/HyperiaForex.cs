public struct CurrencyAmount
{
    private decimal amount;
    private string currency;

    public CurrencyAmount(decimal amount, string currency)
    {
        this.amount = amount;
        this.currency = currency;
    }

    // TODO: implement equality operators
    public static bool operator ==(CurrencyAmount first, CurrencyAmount second)
        => first.currency == second.currency 
            ? first.amount == second.amount 
            : throw new ArgumentException("trying to compare different currencies");

    public static bool operator !=(CurrencyAmount first, CurrencyAmount second) 
        => !(first == second);
    // TODO: implement comparison operators
    public static bool operator <(CurrencyAmount first, CurrencyAmount second)
        => first.currency == second.currency
            ? first.amount < second.amount
            : throw new ArgumentException("trying to compare different currencies");

    public static bool operator >(CurrencyAmount first, CurrencyAmount second)
        => first.currency == second.currency
            ? first.amount > second.amount
            : throw new ArgumentException("trying to compare different currencies");
    // TODO: implement arithmetic operators
    public static CurrencyAmount operator +(CurrencyAmount first, CurrencyAmount second)
        => first.currency == second.currency
            ? new CurrencyAmount(first.amount + second.amount, first.currency)
            : throw new ArgumentException("trying to compare different currencies");

    public static CurrencyAmount operator -(CurrencyAmount first, CurrencyAmount second)
        => first.currency == second.currency
            ? new CurrencyAmount(first.amount - second.amount, first.currency)
            : throw new ArgumentException("trying to compare different currencies");

    public static CurrencyAmount operator *(CurrencyAmount first, decimal second)
        => new(first.amount * second, first.currency);

    public static CurrencyAmount operator *(decimal first, CurrencyAmount second)
        => new(first * second.amount, second.currency);
    
    public static CurrencyAmount operator /(CurrencyAmount first, decimal second)
        => new(first.amount / second, first.currency);
    
    // TODO: implement type conversion operators
    public static explicit operator double(CurrencyAmount amount)
        => (double)amount.amount;

    public static implicit operator decimal(CurrencyAmount amount)
        => amount.amount;
}
