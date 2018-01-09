using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var firstLength = input[0];
        var secondLength = input[1];

        var firstNumbers = new Dictionary<int, int>();
        var secondNumbers = new Dictionary<int, int>();

        for (var i = 0; i < firstLength; i++)
        {
            var n = int.Parse(Console.ReadLine());
            if (firstNumbers.ContainsKey(n))
                firstNumbers.Remove(n);
            else firstNumbers.Add(n, 1);
        }

        for (var i = 0; i < secondLength; i++)
        {
            var n = int.Parse(Console.ReadLine());
            if (secondNumbers.ContainsKey(n))
                secondNumbers.Remove(n);
            else secondNumbers.Add(n, 1);
        }
        var forPrint = new List<int>();
        foreach (var number in firstNumbers)
            if (secondNumbers.ContainsKey(number.Key)) forPrint.Add(number.Key);
        Console.WriteLine(string.Join(" ", forPrint));
    }
}