public class ShowCar : Car
{
    public ShowCar(string brand, string model, int productionYear, int horsePower, int acceleration, int suspension, int durability) : base(brand, model, productionYear, horsePower, acceleration, suspension, durability)
    {
    }

    public int Stars { get; set; }

    public override void Tune(int tuneIndex, string addOn)
    {
        base.Tune(tuneIndex, addOn);
        Stars += tuneIndex;
    }

    public override string ToString()
    {
        return $"{base.ToString()}\n{Stars} *";
    }
}
