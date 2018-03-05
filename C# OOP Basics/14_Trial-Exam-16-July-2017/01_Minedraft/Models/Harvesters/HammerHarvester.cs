public class HammerHarvester : Harvester
{
    public HammerHarvester(string id, double oreOutput, double energyRequirement) : base(id, oreOutput, energyRequirement)
    {
    }

    public override double EnergyRequirement
    {
        get => base.EnergyRequirement;

        protected set => base.EnergyRequirement = value + value;
    }

    public override double OreOutput
    {
        get => base.OreOutput;

        protected set => base.OreOutput = value + value * (200 / 100);
    }

    public override string ToString()
    {
        return "Hammer" + base.ToString();
    }
}
