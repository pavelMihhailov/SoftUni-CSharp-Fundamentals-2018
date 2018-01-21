using System;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        Action<string> appendAction = n => Console.WriteLine($"Sir {n}");

        Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList().ForEach(n => appendAction(n));
    }
}
