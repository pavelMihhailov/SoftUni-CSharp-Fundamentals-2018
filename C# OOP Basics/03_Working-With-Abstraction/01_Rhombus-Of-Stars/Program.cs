using System;

class Program
{
    public static void Main()
    {
        var size = int.Parse(Console.ReadLine());

        for (var i = 1; i <= size; i++)
        {
            PrintRow(size, i);
        }

        for (var i = size - 1; i >= 1; i--)
        {
            PrintRow(size, i);
        }
    }

    private static void PrintRow(int size, int stars)
    {
        Console.Write(new string(' ', size - stars));
        for (var i = 1; i < stars; i++)
        {
            Console.Write("* ");
        }
        Console.WriteLine("*");
    }
}