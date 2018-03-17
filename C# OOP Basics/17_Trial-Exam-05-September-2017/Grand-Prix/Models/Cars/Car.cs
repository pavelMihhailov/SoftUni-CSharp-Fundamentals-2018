using System;

public class Car
{
    public Car(int hp, double fuelAmount, Tyre tyre)
    {
        Hp = hp;
        FuelAmount = fuelAmount;
        Tyre = tyre;
    }

    public int Hp { get; set; }

    private double fuelAmount;

    public double FuelAmount
    {
        get => fuelAmount;
        private set
        {
            if (value < 0) throw new ArgumentException("Out of fuel");
            fuelAmount = value > 160 ? 160 : value;
        }
    }

    public Tyre Tyre { get; private set; }

    public void ReduceFuelAmount(int length, double fuelConsumption)
    {
        FuelAmount -= length * fuelConsumption;
    }

    public void Refuel(double fuelToFill)
    {
        FuelAmount += fuelToFill;
    }

    public void ChangeTyre(Tyre tyre)
    {
        Tyre = tyre;
    }
}
