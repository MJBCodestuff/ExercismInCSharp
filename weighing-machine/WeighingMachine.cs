class WeighingMachine(int precision)
{
    // TODO: define the 'Precision' property
    public int Precision { get; } = precision;

    // TODO: define the 'Weight' property
    public double Weight { get; 
        set
        {
            if (value >= 0)
            {
                field = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        } }
    
    // TODO: define the 'TareAdjustment' property
    public double TareAdjustment { get; set; } = 5;
    // TODO: define the 'DisplayWeight' property
    public string DisplayWeight
    {
        get
        {
            string formatString = string.Concat("{0:F", Precision, "} kg");
            return string.Format(formatString, (Weight - TareAdjustment));
        }
    }
}
