public class FireBender : Bender
{
    public FireBender(string name, int power, double heatAggression) : base(name, power)
    {
        HeatAggression = heatAggression;
    }

    public double HeatAggression { get; set; }

    public override double TotalPower()
    {
        return Power * HeatAggression;
    }

    public override string ToString()
    {
        return $"Fire Bender: {Name}, Power: {Power}, Heat Aggression: {HeatAggression:f2}";
    }
}
