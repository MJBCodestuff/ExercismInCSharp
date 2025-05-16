public static class RomanNumeralExtension
{

    
    // proper solution
    public static string ToRoman(this int value)
    {
        Dictionary<string, int> romanNumbers = new Dictionary<string, int>
        {
            { "M", 1000 },
            { "CM", 900 },
            { "D", 500 },
            { "CD", 400 },
            { "C", 100 },
            { "XC", 90 },
            { "L", 50 },
            { "XL", 40 },
            { "X", 10 },
            { "IX", 9 },
            { "V", 5 },
            { "IV", 4 },
            { "I", 1 }
        };

        string result = "";
        for (int i = 0; i < romanNumbers.Keys.Count; i++)
        {
            int current = romanNumbers[romanNumbers.Keys.ElementAt(i)];
            while (value >= current)
            {
                result += romanNumbers.Keys.ElementAt(i);
                value -= current;
            }
        }
        return result;
        


    }
    
    
    /* First attempt, intuitive solution.
    public static string ToRoman(this int value)
    {
        int thousands = value / 1000;
        int hundreds = (value - thousands * 1000) / 100;
        int tens = (value - thousands * 1000 - hundreds * 100) / 10;
        int ones = value - thousands * 1000 - hundreds * 100 - tens * 10;

        string result = "";
        for (int i = 0; i < thousands; i++)
        {
            result += "M";
        }

        switch (hundreds)
        {
            case 4:
                result += "CD";
                hundreds -= 4;
                break;
            case 9:
                result += "CM";
                hundreds -= 9;
                break;
            case >= 5:
                result += "D";
                hundreds -= 5;
                break;
        }

        for (int i = 0; i < hundreds; i++)
        {
            result += "C";
        }
        
        switch (tens)
        {
            case 4:
                result += "XL";
                tens -= 4;
                break;
            case 9:
                result += "XC";
                tens -= 9;
                break;
            case >= 5:
                result += "L";
                tens -= 5;
                break;
        }

        for (int i = 0; i < tens; i++)
        {
            result += "X";
        }
        
        switch (ones)
        {
            case 4:
                result += "IV";
                ones -= 4;
                break;
            case 9:
                result += "IX";
                ones -= 9;
                break;
            case >= 5:
                result += "V";
                ones -= 5;
                break;
        }

        for (int i = 0; i < ones; i++)
        {
            result += "I";
        }
        
        return result;
        

    }
    
    */
}