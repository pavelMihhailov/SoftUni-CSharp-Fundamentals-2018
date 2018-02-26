public class Tesla : Car
{
    public Tesla(string model, string color, int battery) : base(model, color, battery)
    {
    }

    public override string ToString()
    {
        return $"{Color} Tesla {Model} with {Battery} Batteries\n{Start()}\n{Stop()}";
    }
}
