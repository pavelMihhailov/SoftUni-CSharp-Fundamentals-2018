using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        List<Car> listCars = new List<Car>();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split();
            Engine engine = new Engine(int.Parse(input[1]), int.Parse(input[2]));
            Cargo cargo = new Cargo(int.Parse(input[3]), input[4]);
            Tire[] tires = new Tire[4];
            tires[0] = new Tire(double.Parse(input[5]), int.Parse(input[6]));
            tires[1] = new Tire(double.Parse(input[7]), int.Parse(input[8]));
            tires[2] = new Tire(double.Parse(input[9]), int.Parse(input[10]));
            tires[3] = new Tire(double.Parse(input[11]), int.Parse(input[12]));
            Car newCar = new Car(input[0], engine, cargo, tires);
            listCars.Add(newCar);
        }

        string command = Console.ReadLine();

        if (command == "fragile")
        {
            foreach (var car in listCars.Where(x => x.Cargo.Type.Equals("fragile") && x.Tires.Any(t => t.Pressure < 1)))
            {
                Console.WriteLine(car.Model);
            }
        }
        else
        {
            foreach (var car in listCars.Where(x => x.Cargo.Type.Equals("flamable") && x.Engine.Power > 250))
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}
