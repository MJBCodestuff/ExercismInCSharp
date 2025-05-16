public class SpaceAge
{
    private enum _planet
    {
        Mercury,
        Venus,
        Earth,
        Mars,
        Jupiter,
        Saturn,
        Uranus,
        Neptune
    }
    private static readonly Dictionary<_planet, double> _orbitInSeconds = new();

    private int _seconds;
    
    public SpaceAge(int seconds)
    {
        _seconds = seconds;
        _orbitInSeconds[_planet.Earth] = 31557600;
        _orbitInSeconds[_planet.Mercury] = 0.2408467 * _orbitInSeconds[_planet.Earth];
        _orbitInSeconds[_planet.Venus] = 0.61519726 * _orbitInSeconds[_planet.Earth];
        _orbitInSeconds[_planet.Mars] = 1.8808158 * _orbitInSeconds[_planet.Earth];
        _orbitInSeconds[_planet.Jupiter] = 11.862615 * _orbitInSeconds[_planet.Earth];
        _orbitInSeconds[_planet.Saturn] = 29.447498 * _orbitInSeconds[_planet.Earth];
        _orbitInSeconds[_planet.Uranus] = 84.016846 * _orbitInSeconds[_planet.Earth];
        _orbitInSeconds[_planet.Neptune] = 164.79132 * _orbitInSeconds[_planet.Earth];
        
    }

    public double OnEarth() => _seconds / _orbitInSeconds[_planet.Earth];

    public double OnMercury() => _seconds / _orbitInSeconds[_planet.Mercury];

    public double OnVenus() => _seconds / _orbitInSeconds[_planet.Venus];

    public double OnMars() => _seconds / _orbitInSeconds[_planet.Mars];

    public double OnJupiter() => _seconds / _orbitInSeconds[_planet.Jupiter];

    public double OnSaturn() => _seconds / _orbitInSeconds[_planet.Saturn];

    public double OnUranus() => _seconds / _orbitInSeconds[_planet.Uranus];

    public double OnNeptune() => _seconds / _orbitInSeconds[_planet.Neptune];
}