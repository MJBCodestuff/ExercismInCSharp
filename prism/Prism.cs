public static class Prism
{
    public readonly record struct LaserInfo(double X, double Y, double Angle);

    public readonly record struct PrismInfo(int Id, double X, double Y, double Angle);

    public static double toRad(double angle)
    {
        return angle * Math.PI / 180;
    }
    private record MinMax()
    {
        public double maxX { get; set; } = 1;
        public double maxY { get; set; } = 1;
        public double minX { get; set; } = -1;
        public double minY { get; set; } = -1;
    }
    public static int[] FindSequence(LaserInfo laser, PrismInfo[] prisms)
    {
        (double, double) currentPosition = (laser.X, laser.Y);
        double currentAngle = laser.Angle;
        var minmax = new MinMax();
        List<int> sequence = [];
        int safetyMarginForFloatMath = 1;
        foreach (var prism in prisms)
        {
            if ( minmax.maxX <  prism.X ) minmax.maxX = prism.X + safetyMarginForFloatMath;
            if ( minmax.maxY <  prism.Y ) minmax.maxY = prism.Y + safetyMarginForFloatMath;
            if ( minmax.minX > prism.X ) minmax.minX = prism.X - safetyMarginForFloatMath;
            if ( minmax.minY > prism.Y ) minmax.minY = prism.Y - safetyMarginForFloatMath;
        }

        double epsilon = 0.001;
        while (currentPosition.Item1 <= minmax.maxX && currentPosition.Item2 <= minmax.maxY
               && currentPosition.Item1 >= minmax.minX && currentPosition.Item2 >= minmax.minY)
        {
            currentPosition.Item1 += Math.Cos(toRad(currentAngle))*0.01;
            currentPosition.Item2 += Math.Sin(toRad(currentAngle))*0.01;
            foreach (var prism in prisms)
            {
                if (Math.Abs(prism.X - currentPosition.Item1) < epsilon 
                    && Math.Abs(prism.Y - currentPosition.Item2) < epsilon)
                {
                    sequence.Add(prism.Id);
                    currentAngle += prism.Angle;
                }
            }
        }
        return sequence.ToArray();
        
    }
}
