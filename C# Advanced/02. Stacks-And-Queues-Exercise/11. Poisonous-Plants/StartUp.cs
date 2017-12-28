using System;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var plants = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var days = new int[n];
        var minElement = new int[n];

        var min = int.MaxValue;
        for (var i = 0; i < n; i++)
        {
            if (plants[i] < min)
                min = plants[i];
            minElement[i] = min;
        }

        var max = 0;
        var maxIndex = 0;

        for (var i = 1; i < n; i++)
        {
            if (plants[i] > plants[i - 1])
            {
                days[i] = 1;
                if (days[i] >= max)
                {
                    maxIndex = i;
                    max = days[i];
                }
                continue;
            }

            if (plants[i] > minElement[i])
                if (plants[i] > plants[maxIndex])
                    days[i] = days[i - 1] + 1;
                else
                    days[i] = days[maxIndex] + 1;
            if (plants[i] == minElement[i])
                max = 0;

            if (days[i] >= max)
            {
                maxIndex = i;
                max = days[i];
            }
        }
        Console.WriteLine(days.Max());
    }
}