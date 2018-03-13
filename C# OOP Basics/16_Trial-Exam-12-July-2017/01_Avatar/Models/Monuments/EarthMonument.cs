public class EarthMonument : Monument
{
    public EarthMonument(string name, int earthAffinity) : base(name)
    {
        EarthAffinity = earthAffinity;
    }

    public int EarthAffinity { get; set; }

    public override int AffinityType()
    {
        return EarthAffinity;
    }

    public override string ToString()
    {
        return "Earth " + base.ToString() + $"Earth Affinity: {EarthAffinity}";
    }
}
