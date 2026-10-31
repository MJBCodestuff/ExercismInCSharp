public static class Prism
{
    public readonly record struct LaserInfo(double X, double Y, double Angle);

    public readonly record struct PrismInfo(int Id, double X, double Y, double Angle);

    public static double ToRad(double angle)
    {
        return angle * Math.PI / 180;
    }
    
    public static int[] FindSequence(LaserInfo laser, PrismInfo[] prisms)
    {
        (double, double) currentPosition = (laser.X, laser.Y);
        double currentAngle = laser.Angle;
        List<int> sequence = [];
        const double epsilon = 0.01;
        while (true)
        {
            double currentAngleRad = ToRad(currentAngle);
            double smallestDistance =  double.MaxValue;
            int closestPrismId = -1;

            foreach (var prism in prisms)
            {
                double deltaX = prism.X - currentPosition.Item1;
                double deltaY = prism.Y - currentPosition.Item2;

                double directionVectorX = Math.Cos(currentAngleRad);
                double directionVectorY = Math.Sin(currentAngleRad);

                bool aligned = Math.Abs(deltaX * directionVectorY - deltaY * directionVectorX) < epsilon;
                if (aligned)
                {
                    double distance = deltaX * directionVectorX + deltaY * directionVectorY;

                    if (distance > epsilon && distance < smallestDistance)
                    {
                        smallestDistance = distance;
                        closestPrismId = prism.Id;
                    }
                }
            }

            if (closestPrismId == -1)
            {
                break; // no aligned Prism found
            }
            
            sequence.Add(closestPrismId);
            var chosenPrism = (from prism in prisms where prism.Id == closestPrismId select prism).First();
            currentPosition = (chosenPrism.X, chosenPrism.Y);
            currentAngle += chosenPrism.Angle;
            
        }
        
        
        
        return sequence.ToArray();
        
    }
}
