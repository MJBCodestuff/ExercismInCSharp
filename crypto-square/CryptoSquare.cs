using System.Collections;
using System.Text;
using System.Text.RegularExpressions;

using Xunit.Internal;

public static class CryptoSquare
{
    public static string NormalizedPlaintext(string plaintext)
    {
        StringBuilder builder = new StringBuilder();
        
        foreach (var c in plaintext.Where(c => !char.IsPunctuation(c) && !char.IsWhiteSpace(c)))
        {
            builder.Append(c);
        }
        return builder.ToString().ToLower();
    }

    public static IEnumerable<string> PlaintextSegments(string plaintext)
    {
        List<string> segments = [];
        plaintext = NormalizedPlaintext(plaintext);
        int length = plaintext.Length;
        int c = (int)Math.Ceiling(Math.Sqrt(length));
        int r = (int)Math.Ceiling(((double)length / c));
        int current = 0;
        int addedSpaces = c*r - plaintext.Length;
        for (int i = 0; i < addedSpaces; i++)
        {
            plaintext = $"{plaintext} ";
        }
        for (int i = 0; i < r; i++)
        {
            segments.Add(plaintext.Substring(current, c));
            current += c;
        }
        return segments;
        
    }

    public static string Encoded(string plaintext)
    {
        IEnumerable<string> segments = PlaintextSegments(plaintext);
        List<string> segmentsList = segments.CastOrToList();
        LinkedList<char> encodedList = [];
        int c = segmentsList[0].Length;
        int r = segmentsList.Count;

        for (int i = 0; i < c; i++)
        {
            for (int j = 0; j < r; j++)
            {
                encodedList.AddLast(segmentsList[j][i]);
            }
            
        }

        return new string(encodedList.ToArray());
    }

    public static string Ciphertext(string plaintext)
    {
        string normalized = NormalizedPlaintext(plaintext);
        if (normalized.Equals(""))
        {
            return "";
        }
        string encodedText = Encoded(plaintext);
        int length = normalized.Length;
        int c = (int)Math.Ceiling(Math.Sqrt(length));
        int r = (int)Math.Ceiling(((double)length / c));
        int currentIndex = 0;
        for (int i = 0; i < c-1; i++)
        {
            currentIndex += r;
            encodedText = encodedText.Insert(currentIndex, " ");
            currentIndex += 1;
        }
        return encodedText;
    }
}