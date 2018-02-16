using System;

public class Program
{
    public static void Main()
    {
        PriceCalculator priceCalc = new PriceCalculator();
        
        decimal totalPrice = priceCalc.Calculate(Console.ReadLine().Split());
        Console.WriteLine($"{totalPrice:f2}");
    }
}