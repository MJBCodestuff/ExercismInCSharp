public static class BookStore
{
    // prices for the amount of different books in a group
    static decimal[] priceMultiplier = new decimal[] {0m, 8m, 15.2m, 21.6m, 25.6m, 30m};

    public static decimal Total(IEnumerable<int> books)
    {
        // group by bookNr 
        List<int> bookCounts = books.GroupBy(book => book).Select(books => books.Count()).ToList();
        // List of all price possibilities to find the lowest one
        List<decimal> prices =  new List<decimal>();
        
        // trivial case - necessary because we directly access index 0 and 1
        if (bookCounts.Count == 1)
        {
            return bookCounts[0] * 8m;
        }

        while (bookCounts.Count > 1)
        {
            decimal total = 0m;
            int used = 0;
            // put the books with the lowest amount first - otherwise we end up using antimatter books with negative prices you goddamn donut
            bookCounts.Sort();
            for (int i = 0; i < bookCounts.Count; i++)
            {
                // form the current biggest possible group and calculate the price
                total += (bookCounts[i] - used) * priceMultiplier[bookCounts.Count - i];

                // check off used books
                if (bookCounts[i] > used)
                {
                    used = bookCounts[i];
                }
            }
            prices.Add(total);
            // [11222] can also be used as [2222] -> exploring the different grouping options
            bookCounts[0]--;
            bookCounts[1]++;
            bookCounts.Remove(0);
        }
        
        // lowest price in the list is the solution
        return prices.Count > 0 ? prices.Min() : 0m;
    }
    
    // this whole bugger took way longer than it should have
    
}
