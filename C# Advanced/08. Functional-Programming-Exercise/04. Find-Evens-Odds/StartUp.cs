using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main(string[] args)
    {
        Predicate<int> predicate;

        int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
        string command = Console.ReadLine();

        if (command == "even") predicate = n => Math.Abs(n) % 2 == 0;
        else predicate = n => Math.Abs(n) % 2 != 0;

        PrintResult(numbers, command, predicate);
    }

    public static void PrintResult(int[] numbers, string command, Predicate<int> predicate)
    {
        List<int> result = new List<int>();
        for (int i = numbers[0]; i <= numbers[1]; i++)
        {
            if (predicate(i)) result.Add(i);
        }
        Console.WriteLine(string.Join(" ", result));
    }
}
