public class WordSearch
{
    private readonly List<(char, (int x, int y))> _grid = [];
    private readonly int _lineLength;
    private readonly int _columnLength;
    
    public WordSearch(string grid)
    {
        string[] split = grid.Split("\n");
        _lineLength = split[0].Length;
        _columnLength = split.Length;
        for (var y = 0; y < split.Length; y++)
        {
            string s = split[y];
            for (int x = 0; x < s.Length; x++)
            {
                _grid.Add((s[x], (x, y)));
            }
        }
    }

    public Dictionary<string, ((int, int), (int, int))?> Search(string[] wordsToSearchFor)
    {
        Dictionary<string, ((int, int), (int, int))?> result = new Dictionary<string, ((int, int), (int, int))?>();
        foreach (string word in wordsToSearchFor)
        {
            result.Add(word, null);
            List<(char, (int x, int y))> candidates = _grid.Where(x => word[0] == x.Item1).ToList();
            foreach (var candidate in candidates)
            {
                (int, int)[] secondLetter = findDirection(word[1], candidate.Item2);
                if (secondLetter.Length == 0) continue; // no adjacent letter fits the word
                foreach ((int x, int y) coordinate in secondLetter)
                {
                    (int x, int y) offset = (coordinate.x - candidate.Item2.x, coordinate.y -candidate.Item2.y);
                    (int x, int y) currentPosition = coordinate;
                    for (int i = 2; i < word.Length; i++)
                    {
                        currentPosition = (currentPosition.x + offset.x, currentPosition.y + offset.y);
                        // if we fall out of the grid
                        if (currentPosition.x < 0 || currentPosition.y < 0
                                                  || currentPosition.x >= _lineLength
                                                  || currentPosition.y >= _columnLength) break;
                        if (_grid.Where(x => x.Item2 == currentPosition).ToList()[0].Item1 == word[i])
                        {
                            if (i == word.Length -1)
                            {
                                // case we have reached the end of the word
                                // adding 1 each because the required coordinates are 1 based, not 0 based
                                result[word] = ((candidate.Item2.x + 1, candidate.Item2.y + 1),(currentPosition.x + 1, currentPosition.y + 1));
                                break;
                            }
                        }
                        else
                        {
                            // case the current letter doesn't match
                            break;
                        }
                    }
                }
            }
        }

        
        return result;
    }

    private (int, int)[] findDirection(char c, (int x, int y) coordinate)
    {
        // checking for neighboring coordinates that match the character and are not the start coordinate
        List<(char, (int x, int y))> temp = _grid.Where(x => Math.Abs(x.Item2.x - coordinate.x) <= 1 
                                                             && Math.Abs(x.Item2.y - coordinate.y) <= 1 
                                                             && x.Item1 == c
                                                             && !(x.Item2.x == coordinate.x 
                                                                  && x.Item2.y == coordinate.y)).ToList();
        return temp.Select(x => (x.Item2.x, x.Item2.y)).ToArray();
    }

    
}