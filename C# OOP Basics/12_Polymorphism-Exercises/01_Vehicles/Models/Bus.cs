using System;

public class Bus : Vehicle
{
    public Bus(double fuelQuantity, double litersPerKm, double tankCapacity) : base(fuelQuantity, litersPerKm, tankCapacity)
    {
    }

    public override void Drive(double distance, bool hasAc)
    {
        double totalFuelConsumption = base.FuelConsumptionPerkKm;
        if (hasAc)
        {
            totalFuelConsumption += 1.4;
        }

        if (base.FuelQuantity < distance * totalFuelConsumption)
        {
            Console.WriteLine($"{this.GetType().Name} needs refueling");
        }
        else
        {
            base.FuelQuantity -= distance * totalFuelConsumption;
            Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
        }
    }
}