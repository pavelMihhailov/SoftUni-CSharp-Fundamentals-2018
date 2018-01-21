using System;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        int wantedSum = int.Parse(Console.ReadLine());
        string[] names = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

        Func<string, int, bool> hasMoreSum = (str, wantSum) =>
            str.ToCharArray().Select(charr => (int)charr).Sum() >= wantSum;
        Func<string[], int, Func<string, int, bool>, string> firstFoundName = (namess, wantSum, func) =>
            names.FirstOrDefault(str => func(str, wantSum));
        Console.WriteLine(firstFoundName(names, wantedSum, hasMoreSum));
    }
}
