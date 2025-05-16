public static class KillerSudokuHelper
{
    static List<int[]> solutions = [];
    public static IEnumerable<int[]> Combinations(int sum, int size, int[] exclude)
    {
        List<int> digits = [1, 2, 3, 4, 5, 6, 7, 8, 9];
        PossibleCombinations(digits.Except(exclude).ToArray(), size, 0, new int[size]);
        solutions.RemoveAll(x => x.Sum() != sum);
        solutions.Sort((x, y )=> x[0].CompareTo(y[0]));
        return solutions;
    }

    private static void PossibleCombinations(int[] set, int size, int start, int[] result)
    {
        if (size == 0)
        {
            solutions.Add(result.Clone() as int[] ?? throw new InvalidOperationException());
            return;
        }

        for (int i = start; i <= set.Length - size; i++)
        {
            result[^size] = set[i];
            PossibleCombinations(set, size - 1, i + 1, result);
        }
    }
    
}
