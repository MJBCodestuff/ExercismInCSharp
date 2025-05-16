public class Anagram
{
    private string _baseWord;
    private IOrderedEnumerable<char> _sortedBase;

    public Anagram(string baseWord)
    {
        _baseWord = baseWord.ToLower();
        _sortedBase = _baseWord.Order();
    }

    public string[] FindAnagrams(string[] potentialMatches)
    {
        List<string> matches = [];
        foreach (string potentialMatch in potentialMatches)
        {
            string candidate = potentialMatch.ToLower();
            // anagrams are not identity
            if (_baseWord.Equals(candidate)) continue;
            IOrderedEnumerable<char> sortedCandidate = candidate.Order();
            // ordering both words by ascii value will make any word identical to its anagrams
            if (_sortedBase.SequenceEqual(sortedCandidate)) matches.Add(potentialMatch);
        }
        return matches.ToArray();
    }
}