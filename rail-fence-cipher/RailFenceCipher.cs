using System.Text;

public class RailFenceCipher
{
    private int _rails;
    private int _lengthOfOneRoundtrip;
    
    public RailFenceCipher(int rails)
    {
        _rails = rails;
        _lengthOfOneRoundtrip = _rails * 2 - 2;
    }

    
    
    private int Rail(int index)
    {
        // trivial case, belongs on first rail
        if (index % _lengthOfOneRoundtrip == 0) {
            return 0;

        }
        // trivial case, belongs on last rail
        if ((index - _rails + 1) % _lengthOfOneRoundtrip == 0) {

            return _rails - 1;
        }
        // belongs on one of the middle rails -> find a value i that describes the difference between rail 0 and the index
        return Enumerable.Range(1, _rails - 1).First(i => (index - i) % _lengthOfOneRoundtrip == 0 ||  (index - _lengthOfOneRoundtrip + i) % _lengthOfOneRoundtrip == 0);

    }

    public string Encode(string input)
    {
        return input
            // first create a list of tuples with the appropriate rail and the character
            .Select((character, index) => Tuple.Create(Rail(index), character))
            // then group the string by rail
            .GroupBy(tuple => tuple.Item1)
            // then select * from each group and turn each group into a string
            .Select(groupOfTuple => new string(groupOfTuple.Select(tuple => tuple.Item2).ToArray()))
            // then concatenate the strings
            .Aggregate((s1, s2) => s1 + s2);
    }

    public string Decode(string input)
    {   
                // first create a list of indices of the length of the input
                return Enumerable.Range(0, input.Length)
                    // then use the rail function to group them into an empty encoded message
                    .GroupBy(Rail)
                    // appends the groups to each other to match the formation of the input
                    .SelectMany(x => x)
                    // zip this list together with the input to match indices to letters
                    .Zip(input)
                    // order by index
                    .OrderBy(tuple => tuple.Item1)
                    // take just the chars
                    .Select(tuple => tuple.Item2)
                    // concatenate into a string
                    .Aggregate("", (x, y) => x + y);
    }
        
    
    
    /* Intuitive solution
    public string Encode(string input)
    {
        StringBuilder[] rails = new StringBuilder[_rails];
        for (int i = 0; i < rails.Length; i++)
        {
            rails[i] = new StringBuilder();
        }

        bool ascending = true;
        int currentRail = 0;
        foreach (char letter in input)
        {
            rails[currentRail].Append(letter);
            if (ascending)
            {
                currentRail++;
                if (currentRail == _rails -1) ascending = false;
            }
            else
            {
                currentRail--;
                if (currentRail == 0) ascending = true;
            }
        }
        
        StringBuilder result = new StringBuilder();
        foreach (StringBuilder stringPart in rails)
        {
            result.Append(stringPart);
        }
        return result.ToString();
    }

    public string Decode(string input)
    {
        StringBuilder[] rails = new StringBuilder[_rails];
        for (int i = 0; i < rails.Length; i++)
        {
            rails[i] = new StringBuilder();
        }
        int[] railLength = new int[_rails];
        int baseLength = input.Length / (_rails * 2 - 2);
        int remainingLength = input.Length % (_rails * 2 -2);
        for (int i = 0; i < railLength.Length; i++)
        {
            if (i == 0 || i == railLength.Length - 1)
            {
                railLength[i] = baseLength;
            }
            else
            {
                railLength[i] = 2 * baseLength;
            }
        }
        
        int currentRail = 0;
        bool ascending = true;
        for (int i = 0; i < remainingLength; i++)
        {
            railLength[currentRail]++;
            if (ascending)
            {
                currentRail++;
                if (currentRail == railLength.Length - 1) ascending = false;
            }
            else
            {
                currentRail--;
                if (currentRail == 0) ascending = true; //should never be hit but just in case
            }
        }

        int currentLetter = 0;
        for (int i = 0; i < _rails; i++)
        {
            rails[i].Append(input.AsSpan(currentLetter, railLength[i]));
            currentLetter += railLength[i];
        }

        CharEnumerator[] enumerators = new CharEnumerator[_rails];
        for (int i = 0; i < rails.Length; i++)
        {
            enumerators[i] = rails[i].ToString().GetEnumerator();
            enumerators[i].MoveNext();
        }

        StringBuilder result = new StringBuilder();
        currentRail = 0;
        ascending = true;
        
        for (int i = 0; i < input.Length; i++)
        {
            result.Append(enumerators[currentRail].Current);
            enumerators[currentRail].MoveNext();
            if (ascending)
            {
                currentRail++;
                if (currentRail == (_rails - 1))
                {
                    ascending = false;
                }
            }
            else
            {
                currentRail--;
                if (currentRail == 0)
                {
                    ascending = true;
                }
            }
        }

        return result.ToString();

    }*/
}