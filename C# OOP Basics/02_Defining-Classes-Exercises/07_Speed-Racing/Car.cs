using System;

public class Car
{
    public string Model { get; set; }
    public double FuelAmount { get; set; }
    public double FuelConsumptionPerKm { get; set; }
    public double DistanceTravelled { get; set; }

    public void CanDriveThatDistance(double distance)
    {
        if (FuelAmount >= distance * FuelConsumptionPerKm)
        {
            FuelAmount -= distance * FuelConsumptionPerKm;
            DistanceTravelled += distance;
        }
        else
        {
            Console.WriteLine($"Insufficient fuel for the drive");
        }
    }
}
