using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        var n = int.Parse(Console.ReadLine());

        var nameYears = new Dictionary<string, int>();

        for (var i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            nameYears.Add(input[0], int.Parse(input[1]));
        }
        var condition = Console.ReadLine();
        var aboveAge = int.Parse(Console.ReadLine());
        var format = Console.ReadLine();

        var tester = Tester(condition, aboveAge);
        var print = PrintAction(format);

        PrinterInvoke(nameYears, tester, print);
    }

    public static Func<int, bool> Tester(string condition, int age)
    {
        switch (condition)
        {
            case "younger": return x => x < age;
            case "older": return x => x >= age;
            default: return null;
        }
    }

    public static Action<KeyValuePair<string, int>> PrintAction(string format)
    {
        switch (format)
        {
            case "name": return x => Console.WriteLine($"{x.Key}");
            case "age": return x => Console.WriteLine($"{x.Value}");
            case "name age": return x => Console.WriteLine($"{x.Key} - {x.Value}");
            default: return null;
        }
    }

    public static void PrinterInvoke(Dictionary<string, int> collection, Func<int, bool> tester,
        Action<KeyValuePair<string, int>> print)
    {
        foreach (var person in collection)
            if (tester(person.Value)) print(person);
    }
}