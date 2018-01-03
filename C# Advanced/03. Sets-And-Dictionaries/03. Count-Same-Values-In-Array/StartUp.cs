using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        double[] numbers = Console.ReadLine()
            .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
            .Select(double.Parse)
            .ToArray();
        SortedDictionary<double, int> countTimes = new SortedDictionary<double, int>();

        for (int i = 0; i < numbers.Length; i++)
        {
            if (countTimes.ContainsKey(numbers[i])) countTimes[numbers[i]]++;
            else countTimes.Add(numbers[i], 1);
        }
        foreach (var value in countTimes)
        {
            Console.WriteLine($"{value.Key} - {value.Value} times");
        }
    }
}
