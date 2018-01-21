using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        int endNum = int.Parse(Console.ReadLine());
        int[] dividers = Console.ReadLine().Split().Select(int.Parse).ToArray();

        List<int> numbers = new List<int>();
        var predicates = dividers.Select(div => (Func<int, bool>)(n => n % div == 0)).ToArray();

        for (int i = 1; i <= endNum; i++)
        {
            if (isValid(predicates, i)) Console.Write($"{i} ");
        }
        Console.WriteLine();
    }

    public static bool isValid(Func<int, bool>[] predicates, int num)
    {
        foreach (var predicate in predicates) if (!predicate(num)) return false;
        return true;
    }
}
