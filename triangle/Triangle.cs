public static class Triangle
{
    private const double Precision = 0.000001;
    
    public static bool IsScalene(double side1, double side2, double side3) => IsTriangle(side1, side2, side3) 
            && Math.Abs(side1 - side2) > Precision
            && Math.Abs(side1 - side3) > Precision
            && Math.Abs(side2 - side3) > Precision;

    public static bool IsIsosceles(double side1, double side2, double side3) => IsTriangle(side1, side2, side3)
            && (Math.Abs(side1 - side2) < Precision 
            || Math.Abs(side1 - side3) < Precision
            || Math.Abs(side2 - side3) < Precision);

    public static bool IsEquilateral(double side1, double side2, double side3) => IsTriangle(side1, side2, side3)
        && Math.Abs(side1 - side2) < Precision 
        && Math.Abs(side2 - side3) < Precision;

    // definition of a triangle, all three sides > 0, any two sides >= the other side
    private static bool IsTriangle(double side1, double side2, double side3) =>
        side1 > 0 && side2 > 0 && side3 > 0 && side1 + side2 >= side3 && side1 + side3 >= side2 &&
        side2 + side3 >= side1;
}