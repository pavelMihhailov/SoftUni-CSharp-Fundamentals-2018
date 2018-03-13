public abstract class Bender
{
    public Bender(string name, int power)
    {
        Name = name;
        Power = power;
    }

    public string Name { get; set; }

    public int Power { get; set; }

    public abstract double TotalPower();
}
