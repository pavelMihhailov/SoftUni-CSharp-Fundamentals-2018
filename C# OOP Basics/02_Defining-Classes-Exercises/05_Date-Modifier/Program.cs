using System;

public class Program
{
    public static void Main()
    {
        string firstDate = Console.ReadLine();
        string secondDate = Console.ReadLine();
        int diff = DateModifier.CalcDiff(firstDate, secondDate);
        Console.WriteLine(diff);
    }
}
