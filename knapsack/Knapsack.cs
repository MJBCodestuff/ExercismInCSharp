public static class Knapsack
{
    public static int MaximumValue(int maximumWeight, (int weight, int value)[] items)
    {
        // using a table one row and one column larger to start the process with trivial case of 0 items and 0 weight
        int[,] m = new int[items.Length + 1, maximumWeight + 1];
        
        for (int i = 1; i < m.GetLength(0); i++)
        {
            for (int j = 1; j < m.GetLength(1) ; j++)
            {
                // if the current item doesn't fit in the current max weight use the value from the previous item
                if (items[i-1].weight > j)
                {
                    m[i, j] = m[i - 1, j];
                }
                else // if the current item fits in the current max weight check if it is optimal or the previous value should be used
                { 
                    m[i,j] = Math.Max(m[i - 1, j], m[i-1, j - items[i-1].weight] + items[i-1].value);
                }
            }
        }
        // the last item in the array is the maximum possible value
        return m[items.Length, maximumWeight];
        
    }
}
