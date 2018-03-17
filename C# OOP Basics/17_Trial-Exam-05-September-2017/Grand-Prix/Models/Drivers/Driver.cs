public abstract class Driver
{
    protected Driver(string name, Car car, double fuelConsumption)
    {
        Name = name;
        TotalTime = 0;
        Car = car;
        FuelConsumption = fuelConsumption;
    }

    public string Name { get; private set; }

    public double TotalTime { get; set; }

    public Car Car { get; private set; }

    public double FuelConsumption { get; protected set; }
    
    public virtual double Speed => (Car.Hp + Car.Tyre.Degradation) / Car.FuelAmount;

    public void ReduceFuelAmount(int length)
    {
        Car.ReduceFuelAmount(length, FuelConsumption);
    }
}
