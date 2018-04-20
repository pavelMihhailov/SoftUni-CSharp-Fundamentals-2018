public abstract class Provider : IProvider
{
    private const int InitialDurability = 1000;
    private const int DurabilityLossPerDay = 100;

    protected Provider(int id, double energyOutput)
    {
        ID = id;
        EnergyOutput = energyOutput;
        Durability = InitialDurability;
    }

    public int ID { get; }

    public double Durability { get; protected set; }

    public double Produce()
    {
        return this.EnergyOutput;
    }

    public void Broke()
    {
        this.Durability -= DurabilityLossPerDay;

        if (this.Durability < 0)
        {
            throw new System.ArgumentException();
        }
    }

    public double EnergyOutput { get; protected set; }

    public void Repair(double val)
    {
        this.Durability += val;
    }
}