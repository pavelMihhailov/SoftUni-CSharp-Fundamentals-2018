using System;
using System.Collections.Generic;
using System.Linq;

public class RawData
{
    public static void Main()
    {
        List<Car> cars = new List<Car>();
        int lines = int.Parse(Console.ReadLine());

        for (int i = 0; i < lines; i++)
        {
            cars.Add(new Car(Console.ReadLine()));
        }

        string command = Console.ReadLine();
        PrintWantedResult(cars, command);
    }

    private static void PrintWantedResult(List<Car> cars, string command)
    {
        if (command == "fragile")
        {
            List<string> fragile = cars
                .Where(x => x.cargoType == "fragile" && x.tires.Any(y => y.Key < 1))
                .Select(x => x.model)
                .ToList();

            Console.WriteLine(string.Join(Environment.NewLine, fragile));
        }
        else
        {
            List<string> flamable = cars
                .Where(x => x.cargoType == "flamable" && x.enginePower > 250)
                .Select(x => x.model)
                .ToList();

            Console.WriteLine(string.Join(Environment.NewLine, flamable));
        }
    }
}
