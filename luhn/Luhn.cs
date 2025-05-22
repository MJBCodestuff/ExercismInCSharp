using System.Text;

public static class Luhn
{
    public static bool IsValid(string number)
    {
        number = number.Replace(" ", "");
        if (number.Length < 2 || number.Any(c => !char.IsDigit(c))) return false;
        int[] digits = new int[number.Length];
        for (int i = 1; i <= number.Length; i++)
        {
            int temp = int.Parse(number[^i].ToString());
            // checking if we are on an even step
            if ((i ^ 1) == (i + 1))
            {
                temp *= 2;
                if (temp > 9) temp -= 9;  
            }
            
            digits[i-1] = temp;
        }

        if (digits.Sum() % 10 == 0) return true;
        return false;
    }
}