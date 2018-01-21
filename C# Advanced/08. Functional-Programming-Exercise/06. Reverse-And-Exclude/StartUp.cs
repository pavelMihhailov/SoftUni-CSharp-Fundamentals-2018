using System;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var numbers = Console.ReadLine().Split().Select(int.Parse);
        int n = int.Parse(Console.ReadLine());

        Func<int, bool> isDivisible = x => x % n != 0;

        var result = numbers.Reverse().Where(isDivisible);

        Console.WriteLine(string.Join(" ", result));
    }
}
