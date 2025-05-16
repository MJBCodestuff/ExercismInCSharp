public static class Rectangles
{

    private static string[] _rows = null!;
    
    /*
     * a-b
     * | |
     * c-d
     */
    public static int Count(string[] rows)
    {
        _rows = rows;
        List<(int, int)> corners = [];
        List<((int, int), (int, int), (int, int), (int, int))> possibleRectangles = [];
        for (int i = 0; i < _rows.Length; i++)
        {
            for (int j = 0; j < _rows[i].Length; j++)
            {
                if (_rows[i][j] == '+')
                {
                    corners.Add((i, j));
                }
            }
        }

        for (int i = 0; i < corners.Count; i++)
        {
            (int, int) a = corners[i];
            // every corner in the same row with a bigger column is a possible b
            List<(int, int)> b = corners.Where(x => x.Item1 == a.Item1 && x.Item2 > a.Item2).ToList();
            // every corner in the same column with a bigger row is a possible c
            List<(int, int)> c = corners.Where(x => x.Item2 == a.Item2 && x.Item1 > a.Item1).ToList();
            List<(int, int)> d = [];
            foreach ((int, int) point in b)
            {
                // any intersections of b and c are possible d
                d.AddRange(corners.Where(x => x.Item2 == point.Item2 
                                              && c.Any(y => y.Item1 == x.Item1)));
            }

            possibleRectangles.AddRange(from dPoint in d 
                from bPoint in b.Where(x => x.Item2 == dPoint.Item2) 
                from cPoint in c.Where(x => x.Item1 == dPoint.Item1) 
                select (a, bPoint, cPoint, dPoint));
        }
        return possibleRectangles.Count(x 
            => CheckIfRectangle(x.Item1, x.Item2, x.Item3, x.Item4));
    }


    /*
     * a-b
     * | |
     * c-d
     */
    private static bool CheckIfRectangle((int, int) a, (int, int) b, (int, int) c, (int, int) d)
    {
        char[] horizontal = ['-', '+'];
        char[] vertical = ['|', '+'];
        // (redundant) check if in the same row and column
        if (a.Item1 != b.Item1 || c.Item1 != d.Item1 || a.Item2 != c.Item2 || b.Item2 != d.Item2)
        {
            return false;
        }
        //case length 1
        if (Math.Abs(a.Item1 - c.Item1) == 1 && Math.Abs(a.Item2 - b.Item2) == 1)
        {
            return true;
        }
        // check for edges if not length 1
        for (int i = a.Item2 + 1; i < b.Item2; i++)
        {
            if (!horizontal.Contains(_rows[a.Item1][i]))
            {
                return false;
            }
        }
        for (int i = c.Item2 + 1; i < d.Item2; i++)
        {
            if (!horizontal.Contains(_rows[c.Item1][i]))
            {
                return false;
            }
        }
        for (int i = a.Item1 + 1; i < c.Item1; i++)
        {
            if (!vertical.Contains(_rows[i][a.Item2]))
            {
                return false;
            }
        }
        for (int i = b.Item1 + 1; i < d.Item1; i++)
        {
            if (!vertical.Contains(_rows[i][b.Item2]))
            {
                return false;
            }
        }
        // if every edge is present
        return true;

    }
}