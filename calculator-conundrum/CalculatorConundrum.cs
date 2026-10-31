public static class SimpleCalculator
{
    public static string Calculate(int operand1, int operand2, string? operation)
    {
        try
        {
            int result = operation switch
            {
                "+" => operand1 + operand2,
                "/" => operand1 / operand2,
                "*" => operand1 * operand2,
                "" => throw new ArgumentException("Operator can not be empty"),
                null => throw new ArgumentNullException("Operator can not be NULL"),
                _ => throw new ArgumentOutOfRangeException("Invalid operator symbol")
            };

            return $"{operand1} {operation} {operand2} = {result}";
        }
        catch (DivideByZeroException)
        {
            return "Division by zero is not allowed.";
        }
    }
}
