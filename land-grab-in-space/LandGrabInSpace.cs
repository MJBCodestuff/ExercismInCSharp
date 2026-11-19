using System.Diagnostics.CodeAnalysis;

public struct Coord : IEquatable<Coord>
{
    public Coord(ushort x, ushort y)
    {
        X = x;
        Y = y;
    }

    public ushort X { get; }
    public ushort Y { get; }

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        return base.Equals(obj);
    }

    public bool Equals(Coord other)
    {
        return X == other.X && Y == other.Y;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }
}

public struct Plot(Coord nw, Coord ne, Coord sw, Coord se)
    : IEquatable<Plot>
{
    public Coord NW { get; } = nw;
    public Coord NE { get; } = ne;
    public Coord SW { get; } = sw;
    public Coord SE { get; } = se;

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        return base.Equals(obj);
    }

    public bool Equals(Plot other)
    {
        return NW.Equals(other.NW) && NE.Equals(other.NE) && SW.Equals(other.SW) && SE.Equals(other.SE);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(NW, NE, SW, SE);
    }
}


public class ClaimsHandler
{
    private HashSet<Plot> _claims = [];
    private Plot? _lastclaim;
    public void StakeClaim(Plot plot)
    {
        _claims.Add(plot);
        _lastclaim = plot;
    }

    public bool IsClaimStaked(Plot plot)
        => _claims.Any(x=>x.Equals(plot));

    public bool IsLastClaim(Plot plot)
        => plot.Equals(_lastclaim);


    public Plot GetClaimWithLongestSide()
        => _claims.MaxBy(plot =>
            new List<int>([plot.SE.X - plot.SW.X,
                    plot.SE.Y - plot.NE.Y,
                    plot.SW.Y - plot.NW.Y,
                    plot.NE.X - plot.NW.X])
                .Max());

}
