public class SpiralMatrix
{
    public static int[,] GetMatrix(int size)
    {
        int[,] matrix = new int[size, size];
        int total = size * size;

        int[] position = [0, 0]; // y, x
        bool towardsRight = true;
        bool towardsDown = false;
        int limit = 0;
        for (int i = 1; i <= total; i++)
        {
            matrix[position[0], position[1]] = i;
            // going down
            if (towardsRight && towardsDown)
            {
                position[0]++;
                // position bottom right
                if (position[0] == size - 1 - limit)
                {
                    towardsRight = false;
                }
            }
            // going right
            else if (towardsRight)
            {
                position[1]++;
                // position top right
                if (position[1] == size -1 - limit)
                {
                    towardsDown = true;
                }
            }
            // going left
            else if (towardsDown)
            {
                position[1]--;
                // position bottom left
                if (position[1] == 0 + limit)
                {
                    towardsDown = false;
                    limit++;
                }
            }
            // going up
            else
            {
                position[0]--;
                // position top left
                if (position[0] == 0 + limit)
                {
                    towardsRight = true;
                }
            }

           
            
            
        }
        return matrix;
    }
}
