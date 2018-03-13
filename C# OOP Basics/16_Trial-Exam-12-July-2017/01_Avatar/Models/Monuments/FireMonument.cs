public class FireMonument : Monument
{
    public FireMonument(string name, int fireAffinity) : base(name)
    {
        FireAffinity = fireAffinity;
    }

    public int FireAffinity { get; set; }

    public override int AffinityType()
    {
        return FireAffinity;
    }

    public override string ToString()
    {
        return "Fire " + base.ToString() + $"Fire Affinity: {FireAffinity}";
    }
}
