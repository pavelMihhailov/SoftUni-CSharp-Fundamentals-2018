using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        int[] firstLine = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] secondLine = Console.ReadLine().Split().Select(int.Parse).ToArray();

        Queue<int> resultStack = new Queue<int>(secondLine);

        int deleteTimes = firstLine[1];
        int checkElement = firstLine[2];

        for (int i = 0; i < deleteTimes; i++)
        {
            resultStack.Dequeue();
        }
        if (resultStack.Count == 0) Console.WriteLine("0");
        else if (resultStack.Contains(checkElement)) Console.WriteLine("true");
        else Console.WriteLine(resultStack.Min());
    }
}
