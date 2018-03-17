using System;

public abstract class Tyre
{
    protected Tyre(double hardness)
    {
        Hardness = hardness;
        Degradation = 100;
    }

    public abstract string Name { get; }

    public double Hardness { get; set; }

    private double degradation;

    public virtual double Degradation
    {
        get => degradation;
        protected set
        {
            if (value < 0) throw new ArgumentException("Blown Tyre");
            degradation = value;
        }
    }

    public virtual void ReduceDegradation()
    {
        Degradation -= Hardness;
    }

    public virtual void ChangeTyres(double hardness)
    {
    }

    public virtual void ChangeTyres(double hardness, double grip)
    {
        
    }
}
