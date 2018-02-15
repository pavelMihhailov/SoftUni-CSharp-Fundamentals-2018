using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        int engineLines = int.Parse(Console.ReadLine());

        List<Engine> listEngines = new List<Engine>();
        List<Car> listOfCars = new List<Car>();

        for (int i = 0; i < engineLines; i++)
        {
            string[] line = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            string model = line[0];
            int power = int.Parse(line[1]);
            Engine newEngine = new Engine(model, power);

            if (line.Length == 4)
            {
                string displacement = line[2];
                string efficiency = line[3];
                newEngine.Displacement = displacement;
                newEngine.Efficiency = efficiency;
            }
            else if (line.Length == 3)
            {
                if (Char.IsDigit(line[2][0])) newEngine.Displacement = line[2];
                else newEngine.Efficiency = line[2];
            }
            listEngines.Add(newEngine);
        }

        int carLines = int.Parse(Console.ReadLine());

        for (int i = 0; i < carLines; i++)
        {
            string[] line = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            string model = line[0];
            Engine engine = listEngines.Find(x => x.Model.Equals(line[1]));
            Car newCar = new Car(model, engine);

            if (line.Length == 4)
            {
                newCar.Weight = line[2];
                newCar.Color = line[3];
            }
            else if (line.Length == 3)
            {
                if (Char.IsDigit(line[2][0])) newCar.Weight = line[2];
                else newCar.Color = line[2];
            }
            listOfCars.Add(newCar);
        }

        foreach (var car in listOfCars)
        {
            Console.WriteLine($"{car.Model}:");
            Console.WriteLine($"  {car.Engine.Model}:");
            Console.WriteLine($"    Power: {car.Engine.Power}");
            Console.WriteLine($"    Displacement: {car.Engine.Displacement}");
            Console.WriteLine($"    Efficiency: {car.Engine.Efficiency}");
            Console.WriteLine($"  Weight: {car.Weight}");
            Console.WriteLine($"  Color: {car.Color}");
        }
    }
}