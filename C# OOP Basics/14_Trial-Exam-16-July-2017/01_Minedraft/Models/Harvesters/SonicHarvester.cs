using System;

public class SonicHarvester : Harvester
{
    public SonicHarvester(string id, double oreOutput, double energyRequirement, int sonicFactor) : base(id, oreOutput, energyRequirement)
    {
        SonicFactor = sonicFactor;
        EnergyRequirement /= SonicFactor;
    }

    private int sonicFactor;

    public int SonicFactor
    {
        get => this.sonicFactor;
        protected set => this.sonicFactor = value;
    }

    public override string ToString()
    {
        return "Sonic" + base.ToString();
    }
}
