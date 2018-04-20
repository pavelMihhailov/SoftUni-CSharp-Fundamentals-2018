public abstract class Harvester : IHarvester
{
    private const int InitialDurability = 1000;
    private const int LoseDurabilityAfterChangeMode = 100;
    
    private double oreOutput;
    private double energyRequirement;

    protected Harvester(int id, double oreOutput, double energyRequirement)
    {
        this.ID = id;
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
        this.Durability = InitialDurability;
    }

    public int ID { get; }

    public double OreOutput { get; protected set; }

    public double EnergyRequirement { get; protected set; }

    public virtual double Durability { get; protected set; }

    public double Produce()
    {
        return this.OreOutput;
    }

    public virtual void Broke()
    {
        this.Durability -= LoseDurabilityAfterChangeMode;

        if (this.Durability < 0)
        {
            throw new System.ArgumentException();
        }
    }
}