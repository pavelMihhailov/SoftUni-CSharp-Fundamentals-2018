public class AirBender : Bender
{
    public AirBender(string name, int power, double aerialIntegrity) : base(name, power)
    {
        AerialIntegrity = aerialIntegrity;
    }

    public double AerialIntegrity { get; set; }

    public override double TotalPower()
    {
        return Power * AerialIntegrity;
    }

    public override string ToString()
    {
        return $"Air Bender: {Name}, Power: {Power}, Aerial Integrity: {AerialIntegrity:f2}";
    }
}
