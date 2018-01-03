using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        var input = Console.ReadLine().Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        var parking = new SortedSet<string>();

        while (input[0] != "END")
        {
            var carNumber = input[1];
            var direction = input[0];

            if (direction == "IN")
            {
                parking.Add(carNumber);
            }
            else
            {
                if (parking.Contains(carNumber)) parking.Remove(carNumber);
            }
            input = Console.ReadLine().Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        }
        if (parking.Count == 0) Console.WriteLine("Parking Lot is Empty");
        else
            foreach (var car in parking)
                Console.WriteLine(car);
    }
}