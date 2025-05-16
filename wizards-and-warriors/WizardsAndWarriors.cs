abstract class Character
{
    private string _type { get; }
    
    protected Character(string characterType)
    {
        this._type = characterType;
    }

    public abstract int DamagePoints(Character target);

    public virtual bool Vulnerable()
    {
        return false;
    }

    public override string ToString()
    {
        return $"Character is a {this._type}";
    }
}

class Warrior : Character
{
    public Warrior() : base("Warrior")
    {
    }

    public override int DamagePoints(Character target)
    {
        return target.Vulnerable() ? 10 : 6;
    }
}

class Wizard : Character
{
    private bool _preparedSpell { get; set; }
    
    public Wizard() : base("Wizard")
    {
    }

    public override int DamagePoints(Character target)
    {
        return _preparedSpell ? 12 : 3;
    }

    public void PrepareSpell()
    {
        _preparedSpell = true;
    }
    
    public override bool Vulnerable()
    {
        return !_preparedSpell;
    }
}
