public class Ferrari : ICar
{
    private string driverName;

    public Ferrari(string driverName)
    {
        DriverName = driverName;
    }
    
    public string Model
    {
        get => "488-Spider";
    }

    public string Brakes()
    {
        return "Breakes!";
    }

    public string GasPedal()
    {
        return "Zadu6avam sA!";
    }

    public string DriverName
    {
        get => this.driverName;
        set => this.driverName = value;
    }

    public override string ToString()
    {
        return $"{Model}/{Brakes()}/{GasPedal()}/{DriverName}";
    }
}
