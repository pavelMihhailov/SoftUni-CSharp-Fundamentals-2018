public abstract class Monument
{
    public Monument(string name)
    {
        Name = name;
    }

    public string Name { get; set; }

    public abstract int AffinityType();

    public override string ToString()
    {
        return $"Monument: {Name}, ";
    }
}
