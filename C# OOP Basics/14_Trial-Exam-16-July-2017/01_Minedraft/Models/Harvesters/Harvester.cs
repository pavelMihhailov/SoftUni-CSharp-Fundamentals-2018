using System;
using System.Text;

public abstract class Harvester : Participant
{
    protected Harvester(string id, double oreOutput, double energyRequirement) : base(id)
    {
        OreOutput = oreOutput;
        EnergyRequirement = energyRequirement;
    }
    
    private double oreOutput;

    private double energyRequirement;
    
    public virtual double OreOutput
    {
        get => this.oreOutput;
        protected set
        {
            if (value < 0)
                throw new ArgumentException($"Harvester is not registered, because of it's {nameof(this.OreOutput)}");

            this.oreOutput = value;
        }
    }

    public virtual double EnergyRequirement
    {
        get => this.energyRequirement;
        protected set
        {
            if (value < 0 || value > 20000)
                throw new ArgumentException($"Harvester is not registered, because of it's {nameof(this.EnergyRequirement)}");

            this.energyRequirement = value;
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($" Harvester - {Id}")
            .AppendLine($"Ore Output: {OreOutput}")
            .AppendLine($"Energy Requirement: {EnergyRequirement}");

        return sb.ToString().TrimEnd();
    }
}
