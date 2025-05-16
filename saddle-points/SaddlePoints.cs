public static class SaddlePoints
{
    public static IEnumerable<(int, int)> Calculate(int[,] matrix)
    {
        IEnumerable<(int, int)> result = new List<(int, int)>();
        List<(int, int)> candidates = [];
        for (int column = 0; column < matrix.GetLength(1); column++)
        {
            // find the smallest tree for the column
            (int, int) smallest = (0, column);
            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                if (matrix[row, column] <= matrix[smallest.Item1, smallest.Item2])
                {
                    smallest = (row, column);
                }
            }
            // note the height of the smallest tree
            int smallestvalue = matrix[smallest.Item1, smallest.Item2];
            
            // create list of trees with the height of the smallest tree
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (matrix[row, column] == smallestvalue)
                {
                    candidates.Add((row, column));
                }
            }
        }
            // check viability of each candidate
            foreach ((int, int) candidate in candidates)
            {
                bool viable = true;
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    // if another tree is higher than the candidate it is not viable
                    if (matrix[candidate.Item1, candidate.Item2] < matrix[candidate.Item1, column])
                    {
                        viable = false;
                        break;
                    }
                } 
                if (viable)
                {
                    // non zero based coordinates are expected
                    (int, int) finalCandidate = (candidate.Item1 + 1, candidate.Item2 + 1);
                    result = result.Append(finalCandidate);

                }
            }
            

           
        
        return result;
    }
}
