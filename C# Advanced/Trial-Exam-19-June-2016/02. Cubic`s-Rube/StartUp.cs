using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        int dimension = int.Parse(Console.ReadLine());

        long sum = 0;
        var cellsChanged = 0;

        var line = Console.ReadLine();
        while (line != "Analyze")
        {
            var tokens = line.Split(' ').Select(long.Parse).ToArray();
            List<long> pointsInside = tokens.Take(3).Where(pt => pt < dimension && pt >= 0).ToList();

            if (pointsInside.Count == 3 && tokens[3] != 0)
            {
                sum += tokens[3];
                cellsChanged++;
            }
            line = Console.ReadLine();
        }
        var result = Math.Pow(dimension, 3) - cellsChanged;
        Console.WriteLine(sum);
        Console.WriteLine(result);
    }
}
