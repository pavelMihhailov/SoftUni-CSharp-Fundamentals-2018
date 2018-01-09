using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        string input = Console.ReadLine();
        SortedDictionary<char, int> charsDictionary = new SortedDictionary<char, int>();

        for (int i = 0; i < input.Length; i++)
        {
            if (charsDictionary.ContainsKey(input[i])) charsDictionary[input[i]]++;
            else charsDictionary.Add(input[i], 1);
        }
        foreach (var charr in charsDictionary)
        {
            Console.WriteLine($"{charr.Key}: {charr.Value} time/s");
        }
    }
}
