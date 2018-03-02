public class Car : Vehicle
{
    public Car(double fuelQuantity, double litersPerKm, double tankCapacity) : base(fuelQuantity, litersPerKm + 0.90, tankCapacity)
    {
    }
}