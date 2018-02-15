using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Dictionary<string, Car> cars = new Dictionary<string, Car>();
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split();
            Car newCar = new Car
            {
                Model = input[0],
                FuelAmount = double.Parse(input[1]),
                FuelConsumptionPerKm = double.Parse(input[2])
            };
            cars.Add(input[0], newCar);
        }

        while (true)
        {
            string[] line = Console.ReadLine().Split();
            if (line[0] == "End") break;

            string model = line[1];
            double distance = double.Parse(line[2]);
            cars[model].CanDriveThatDistance(distance);
        }

        foreach (var car in cars)
        {
            Console.WriteLine($"{car.Value.Model} {car.Value.FuelAmount:f2} {car.Value.DistanceTravelled}");
        }
    }
}