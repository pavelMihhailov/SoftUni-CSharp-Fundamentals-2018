using System;

public abstract class Vehicle
{
    private double fuelQuantity;

    protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
    {
        this.TankCapacity = tankCapacity;
        this.FuelQuantity = fuelQuantity;
        this.FuelConsumptionPerkKm = fuelConsumption;
    }

    protected virtual double FuelQuantity
    {
        get => this.fuelQuantity;
        set
        {
            if (value > TankCapacity) this.fuelQuantity = 0;
            else if (value < 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            else
                this.fuelQuantity = value;
        }
    }

    protected double FuelConsumptionPerkKm { get; set; }

    protected double TankCapacity { get; set; }

    public virtual void Drive(double distance, bool hasAc)
    {
        if (this.FuelQuantity < distance * this.FuelConsumptionPerkKm)
        {
            Console.WriteLine($"{this.GetType().Name} needs refueling");
        }
        else
        {
            this.FuelQuantity -= distance * this.FuelConsumptionPerkKm;
            Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
        }
    }

    public virtual void Drive(double distance)
    {
        this.Drive(distance, true);
    }

    public virtual void Refuel(double liters)
    {
        if (liters > this.TankCapacity)
        {
            throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
        }
        if (liters <= 0)
        {
            throw new ArgumentException("Fuel must be a positive number");
        }
        this.FuelQuantity += liters;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
    }
}