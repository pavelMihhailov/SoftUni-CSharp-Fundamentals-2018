using System;

public class StartUp
{
    public static void Main()
    {
        string driverName = Console.ReadLine();

        ICar car = new Ferrari(driverName);
        Console.WriteLine(car.ToString());
    }
}
