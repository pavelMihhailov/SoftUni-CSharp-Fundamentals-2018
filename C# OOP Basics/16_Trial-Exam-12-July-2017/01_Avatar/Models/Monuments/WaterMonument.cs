public class WaterMonument : Monument
{
    public WaterMonument(string name, int waterAffinity) : base(name)
    {
        WaterAffinity = waterAffinity;
    }

    public int WaterAffinity { get; set; }

    public override int AffinityType()
    {
        return WaterAffinity;
    }

    public override string ToString()
    {
        return "Water " + base.ToString() + $"Water Affinity: {WaterAffinity}";
    }
}
