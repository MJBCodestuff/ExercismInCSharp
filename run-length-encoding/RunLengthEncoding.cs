using System.Text;

public static class RunLengthEncoding
{
    public static string Encode(string input)
    {
        int counter = 1;
        // mutable object
        List<char> inputChars = input.ToCharArray().ToList();
        StringBuilder sb = new StringBuilder();
        while (inputChars.Count > 0)
        {
            char current = inputChars[0];
            inputChars.RemoveAt(0);
            // wasn't the last and next is identical
            if (inputChars.Count > 0 && inputChars[0] == current)
            {
                counter++;
            }
            else
            {
                // case lone letter
                if (counter == 1)
                {
                    sb.Append(current);
                }
                // case repeated letter
                else
                {
                    sb.Append($"{counter}{current}");
                    counter = 1;
                }
            }
            

        }
        return sb.ToString();
    }

    public static string Decode(string input)
    {
        StringBuilder sb = new StringBuilder();
        StringBuilder digits = new StringBuilder();
        foreach (char c in input)
        {
            if (char.IsDigit(c))
            {
                // collect digits in stringbuilder so account for multi digit numbers
                digits.Append(c);
            }
            else
            {
                if (digits.Length == 0)
                {
                    sb.Append(c);
                }
                else
                {
                    for (int i = 0; i < int.Parse(digits.ToString()); i++)
                    {
                        sb.Append(c);
                    }

                    digits.Clear();
                }
            }
        }
        return sb.ToString();
    }
}
