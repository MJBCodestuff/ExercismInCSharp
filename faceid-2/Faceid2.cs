public class FacialFeatures
{
    public string EyeColor { get; }
    public decimal PhiltrumWidth { get; }

    public FacialFeatures(string eyeColor, decimal philtrumWidth)
    {
        EyeColor = eyeColor;
        PhiltrumWidth = philtrumWidth;
    }
    // TODO: implement equality and GetHashCode() methods
    public override bool Equals(object? o)
    {
        if (o == null || o.GetType() != typeof(FacialFeatures)) return false;
        FacialFeatures other = (FacialFeatures)o;
        return this.EyeColor == other.EyeColor && this.PhiltrumWidth == other.PhiltrumWidth;

    }

    public override int GetHashCode()
    {
        return HashCode.Combine(EyeColor, PhiltrumWidth);
    }
}

public class Identity
{
    public string Email { get; }
    public FacialFeatures FacialFeatures { get; }

    public Identity(string email, FacialFeatures facialFeatures)
    {
        Email = email;
        FacialFeatures = facialFeatures;
    }

    public override bool Equals(object? o)
    {
        if (o == null || o.GetType() != typeof(Identity)) return false;
        Identity other = (Identity)o;
        return this.Email == other.Email && this.FacialFeatures.Equals(other.FacialFeatures);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Email, FacialFeatures);
    }
}

public class Authenticator
{
    private HashSet<Identity> registered = [];
    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB)
    {
        return faceA.Equals(faceB);
    }

    public bool IsAdmin(Identity identity)
        => identity.Equals(new Identity("admin@exerc.ism", new FacialFeatures("green", 0.9m)));

    public bool Register(Identity identity)
    {
        if (IsRegistered(identity))
        {
            return false;
        }
        this.registered.Add(identity);
        return true;
    }

    public bool IsRegistered(Identity identity)
    {
        return this.registered.Any(id => id.Equals(identity));
    }

    public static bool AreSameObject(Identity identityA, Identity identityB)
    {
        return ReferenceEquals(identityA, identityB);
    }
}
