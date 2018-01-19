using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        List<double> prices = Console.ReadLine()
            .Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
            .Select(double.Parse)
            .Select(x => x * 1.2)
            .ToList();
        foreach (var price in prices) Console.WriteLine($"{price:f2}");
    }
}
