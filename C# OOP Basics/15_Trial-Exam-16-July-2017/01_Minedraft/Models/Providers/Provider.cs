using System;
using System.Text;

public abstract class Provider : Participant
{
    protected Provider(string id, double energyOutput) : base(id)
    {
        EnergyOutput = energyOutput;
    }

    private double energyOutput;
    
    public virtual double EnergyOutput
    {
        get => this.energyOutput;
        protected set
        {
            if (value >= 0 && value < 10000) this.energyOutput = value;
            else throw new ArgumentException($"Provider is not registered, because of it's {nameof(EnergyOutput)}");
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($" Provider - {Id}")
            .AppendLine($"Energy Output: {EnergyOutput}");
        return sb.ToString().TrimEnd();
    }
}
