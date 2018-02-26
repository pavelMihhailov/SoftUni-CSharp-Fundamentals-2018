public class Car : ICar, IElectricCar
{
    private string model;

    private string color;

    private int battery;

    public Car(string model, string color)
    {
        Model = model;
        Color = color;
    }

    public Car(string model, string color, int battery)
    {
        Model = model;
        Color = color;
        Battery = battery;
    }

    public string Model
    {
        get => this.model;
        private set => this.model = value;
    }

    public string Color
    {
        get => this.color;
        private set => this.color = value;
    }

    public int Battery
    {
        get => this.battery;
        private set => this.battery = value;
    }

    public string Start()
    {
        return "Engine start";
    }

    public string Stop()
    {
        return "Breaaak!";
    }
}
