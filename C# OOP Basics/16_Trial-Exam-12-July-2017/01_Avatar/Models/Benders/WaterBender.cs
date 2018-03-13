public class WaterBender : Bender
{
    public WaterBender(string name, int power, double waterClarity) : base(name, power)
    {
        WaterClarity = waterClarity;
    }

    public double WaterClarity { get; set; }

    public override double TotalPower()
    {
        return Power * WaterClarity;
    }

    public override string ToString()
    {
        return $"Water Bender: {Name}, Power: {Power}, Water Clarity: {WaterClarity:f2}";
    }
}
