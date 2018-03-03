using System.Text;

public abstract class Car
{
    protected Car(string brand, string model, int productionYear, int horsePower, int acceleration, int suspension,
        int durability)
    {
        Brand = brand;
        Model = model;
        ProductionYear = productionYear;
        HorsePower = horsePower;
        Acceleration = acceleration;
        Suspension = suspension;
        Durability = durability;
    }

    public string Brand { get; }
    public string Model { get; }
    public int ProductionYear { get; }
    public int HorsePower { get; set; }
    public int Acceleration { get; }
    public int Suspension { get; set; }
    public int Durability { get; set; }

    public virtual void Tune(int tuneIndex, string addOn)
    {
        HorsePower += tuneIndex;
        Suspension += tuneIndex / 2;
    }

    public override string ToString()
    {
        StringBuilder str = new StringBuilder();
        str.AppendLine($"{Brand} {Model} {ProductionYear}")
            .AppendLine($"{HorsePower} HP, 100 m/h in {Acceleration} s")
            .AppendLine($"{Suspension} Suspension force, {Durability} Durability");

        return str.ToString().TrimEnd();
    }
}
