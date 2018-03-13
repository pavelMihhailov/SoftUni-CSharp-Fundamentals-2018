public class AirMonument : Monument
{
    public AirMonument(string name, int airAffinity) : base(name)
    {
        AirAffinity = airAffinity;
    }

    public int AirAffinity { get; set; }

    public override int AffinityType()
    {
        return AirAffinity;
    }

    public override string ToString()
    {
        return "Air " + base.ToString() + $"Air Affinity: {AirAffinity}";
    }
}
