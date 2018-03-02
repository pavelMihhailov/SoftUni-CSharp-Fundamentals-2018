using System;

public class StartUp
{
    public static void Main()
    {
        string[] carInfo = Console.ReadLine().Split();
        Vehicle car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]), double.Parse(carInfo[3]));

        string[] truckInfo = Console.ReadLine().Split();
        Vehicle truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(truckInfo[3]));

        string[] busInfo = Console.ReadLine().Split();
        Vehicle bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3]));

        int commandsCnt = int.Parse(Console.ReadLine());

        for (int i = 0; i < commandsCnt; i++)
        {
            string[] command = Console.ReadLine().Split();
            string action = command[0];
            string vehicle = command[1];
            double amount = double.Parse(command[2]);

            try
            {
                switch (vehicle)
                {
                    case "Car": ExecuteAction(car, action, amount);
                        break;
                    case "Truck": ExecuteAction(truck, action, amount);
                        break;
                    case "Bus": ExecuteAction(bus, action, amount);
                        break;
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        Console.WriteLine(car.ToString());
        Console.WriteLine(truck.ToString());
        Console.WriteLine(bus.ToString());
    }

    private static void ExecuteAction(Vehicle vehicle, string action, double amount)
    {
        switch (action)
        {
            case "Drive": vehicle.Drive(amount); break;
            case "Refuel": vehicle.Refuel(amount); break;
            case "DriveEmpty": vehicle.Drive(amount, false); break;
        }
    }
}
