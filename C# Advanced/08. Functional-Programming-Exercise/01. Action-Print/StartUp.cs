using System;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        Action<string> print = n => Console.WriteLine(n);

        Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
            .ToList().ForEach(name => print(name));
    }
}
