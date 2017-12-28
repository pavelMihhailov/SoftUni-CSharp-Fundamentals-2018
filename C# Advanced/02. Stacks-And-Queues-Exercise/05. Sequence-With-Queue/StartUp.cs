using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        long input = long.Parse(Console.ReadLine());

        Queue<long> sequence = new Queue<long>();
        sequence.Enqueue(input);

        var s = input;
        int skipCount = 0;

        for (int i = 0; i < 49; i++)
        {
            if (i % 3 == 0)
            {
                s = sequence.ToArray().Skip(skipCount).Take(1).ToArray()[0];
                sequence.Enqueue(s + 1);
                skipCount++;
            }
            else if (i % 3 == 1) sequence.Enqueue((2 * s + 1));
            else if (i % 3 == 2) sequence.Enqueue(s + 2);
        }
        Console.WriteLine(string.Join(" ", sequence));
    }
}
