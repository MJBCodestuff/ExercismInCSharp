public static class BinarySearch
{
    
    // Assuming Array.IndexOf doesn't exist
    public static int Find(int[] input, int value)
    {
        if (input.Length == 0) return -1;
        int min = 0;
        int max = input.Length - 1;
        do
        {
            int mid = (min + max) / 2;
            if (input[mid] == value)
            {
                return mid;
            }

            if (input[mid] < value)
            {
                min = mid + 1;
            }

            if (input[mid] > value)
            {
                max = mid - 1;
            }
            
        } while (min <= max);
        return -1;
    }
}