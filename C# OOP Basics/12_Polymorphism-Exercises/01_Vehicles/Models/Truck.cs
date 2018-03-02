using System;

public class Truck : Vehicle
{
    public Truck(double fuelQuantity, double litersPerKm, double tankCapacity) : base(fuelQuantity, litersPerKm + 1.6, tankCapacity)
    {
    }

    public override void Refuel(double amount)
    {
        if (amount > this.TankCapacity)
        {
            throw new ArgumentException($"Cannot fit {amount} fuel in the tank");
        }
        base.Refuel(amount * 0.95);
    }
}