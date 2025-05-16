public static class Dominoes
{
    public static bool CanChain(IEnumerable<(int, int)> dominoes)
    {
        // casting to list to avoid enumerating the dominoes multiple times
        IEnumerable<(int, int)> listDominoes = dominoes.ToList();
        // trivial case: an empty sequence always chains
        if (!listDominoes.Any())
        {
            return true;
        }
        
        // quick check if any number doesn't occur an even amount of time since that is an easy reject
        int[] amount = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0];
        for (int i = 0; i < listDominoes.Count(); i++)
        {
            amount[listDominoes.ElementAt(i).Item1]++;
            amount[listDominoes.ElementAt(i).Item2]++;
        }
        if (amount.Any(nr => nr % 2 != 0))
        {
            return false;
        }
        
        // recursive solution
        (int, int) first = listDominoes.First();
        dominoes = listDominoes.Skip(1);
        return TestChain(dominoes, first, first);
    }


    private static bool TestChain(IEnumerable<(int, int)> remainingDominoes, (int, int) currentDomino, (int, int) firstDomino)
    {
        List<(int, int)> listRemainingDominoes = remainingDominoes.ToList();
        
        // trivial case, none left and current Domino fits to the first -> successful chain
        if (listRemainingDominoes.Count == 0 && currentDomino.Item2 == firstDomino.Item1)
        {
            return true;
        }
        (int, int)[] possibilities = listRemainingDominoes.Where(domino =>
            domino.Item1 == currentDomino.Item2 || domino.Item2 == currentDomino.Item2).ToArray();
        // second trivial case, we have no possibilities left but there are still Dominoes remaining
        if (possibilities.Length == 0 && listRemainingDominoes.Count != 0)
        {
            return false;
        }

        bool possibleFork = false;
        for (int i = 0; i < possibilities.Length; i++)
        {
            // only removing the next currentDomino for this branch. And don't assign by reference, you bloody idiot.
            List<(int, int)> tempList = new List<(int, int)>(listRemainingDominoes);
            tempList.Remove(possibilities[i]);
            if (possibilities[i].Item2 == currentDomino.Item2)
            {
                (possibilities[i].Item2, possibilities[i].Item1) = (possibilities[i].Item1, possibilities[i].Item2);
            }

            possibleFork = possibleFork || TestChain(tempList, possibilities[i], firstDomino);
        }

        return possibleFork;



    }
}

