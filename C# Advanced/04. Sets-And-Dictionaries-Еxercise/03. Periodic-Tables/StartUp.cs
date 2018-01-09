using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        SortedSet<string> result = new SortedSet<string>();

        for (int i = 0; i < n; i++)
        {
            string[] elements = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            for (int j = 0; j < elements.Length; j++)
            {
                result.Add(elements[j]);
            }
        }
        Console.WriteLine(string.Join(" ", result));
    }
}