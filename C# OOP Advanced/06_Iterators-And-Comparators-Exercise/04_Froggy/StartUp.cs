using System;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        Lake lake = new Lake(Console.ReadLine().Split(" ,".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList());

        Console.WriteLine(string.Join(", ", lake));
    }
}
