public static class BookStore_old_backup
{

    private static decimal minimum;
    private static Dictionary<int, Decimal> discounts = new Dictionary<int, decimal>
    {
        { 1, 0 },
        { 2, 0.05m },
        { 3, 0.1m },
        { 4, 0.2m },
        { 5, 0.25m }
    };
    
    
    public static decimal Total(IEnumerable<int> books)
    {
        minimum = decimal.MaxValue;
        Dictionary<int, int> bookCounts = new Dictionary<int, int>()
        {
            { 1, 0 },
            { 2, 0 },
            { 3, 0 },
            { 4, 0 },
            { 5, 0 }
        };
        foreach (int book in books)
        {
            bookCounts[book]++;
        }

        backtrack(bookCounts, new List<List<int>>(), 0);
        return minimum;

    }

    private static void backtrack(Dictionary<int, int> remainingBooks, List<List<int>> sets, decimal currentTotal)
    {
        decimal total = currentTotal;
        if (remainingBooks.Values.Sum() == 0)
        {
            
            total += sets.Sum(set => GroupPrice(set.Count));
            minimum = Math.Min(minimum, total);
            return;
        }

        for (int groupSize = 5; groupSize > 0; groupSize--)
        {
            if (remainingBooks.Values.Aggregate(0, (current, next) => next > 0 ? current + 1 : current) >= groupSize)
            {
               foreach (IEnumerable<int> perm in Permute(remainingBooks.Keys.Where(key => remainingBooks[key] > 0).ToList(), remainingBooks.Keys.Where(key => remainingBooks[key] > 0).ToList().Count))
               {
                   Dictionary<int, int> tempRemaining = remainingBooks;
                   foreach (int book in perm)
                   {
                       if (tempRemaining[book] > 0)
                       {
                           tempRemaining[book]--;
                       }
                       else
                       {
                           break;
                       }
                   }

                   backtrack(tempRemaining, sets.Append(perm.ToList()).ToList(), total);
               } 
            }
        }

        return;
    }


    private static decimal GroupPrice(int size) => size * 8 * (1- discounts[size]);
    
    public static IEnumerable<IEnumerable<T>> Permute<T>(IEnumerable<T> list, int count)
    {
        if (count == 0)
        {
            yield return new T[0];
        }
        else
        {
            int startingElementIndex = 0;
            foreach (T startingElement in list)
            {
                IEnumerable<T> remainingItems = AllExcept(list, startingElementIndex);

                foreach (IEnumerable<T> permutationOfRemainder in Permute(remainingItems, count - 1))
                {
                    yield return Concat<T>(
                        new T[] { startingElement },
                        permutationOfRemainder);
                }
                startingElementIndex += 1;
            }
        }
    }

    // Enumerates over contents of both lists.
    public static IEnumerable<T> Concat<T>(IEnumerable<T> a, IEnumerable<T> b)
    {
        foreach (T item in a) { yield return item; }
        foreach (T item in b) { yield return item; }
    }

    // Enumerates over all items in the input, skipping over the item
    // with the specified offset.
    public static IEnumerable<T> AllExcept<T>(IEnumerable<T> input, int indexToSkip)
    {
        int index = 0;
        foreach (T item in input)
        {
            if (index != indexToSkip) yield return item;
            index += 1;
        }
    }
}
