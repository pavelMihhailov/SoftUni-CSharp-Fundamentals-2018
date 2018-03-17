using System;

public class UltrasoftTyre : Tyre
{
    public UltrasoftTyre(double hardness, double grip) : base(hardness)
    {
        Grip = grip;
    }

    public double Grip { get; set; }

    private double degradation;

    public override string Name => "Ultrasoft";

    public override double Degradation
    {
        get => degradation;
        protected set
        {
            if (value < 30) throw new ArgumentException("Blown tyre");
            degradation = value;
        }
    }

    public override void ReduceDegradation()
    {
        Degradation -= Hardness + Grip;
    }
}
