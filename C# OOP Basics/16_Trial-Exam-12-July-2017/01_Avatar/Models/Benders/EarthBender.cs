public class EarthBender : Bender
{
    public EarthBender(string name, int power, double groundSaturation) : base(name, power)
    {
        GroundSaturation = groundSaturation;
    }

    public double GroundSaturation { get; set; }

    public override double TotalPower()
    {
        return Power * GroundSaturation;
    }

    public override string ToString()
    {
        return $"Earth Bender: {Name}, Power: {Power}, Ground Saturation: {GroundSaturation:f2}";
    }
}
