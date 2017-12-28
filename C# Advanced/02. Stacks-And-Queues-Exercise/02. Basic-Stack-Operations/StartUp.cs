using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        int[] firstLine = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] secondLine = Console.ReadLine().Split().Select(int.Parse).ToArray();
        
        int elementsToPop = firstLine[1];
        int hasElement = firstLine[2];

        Stack<int> stack = new Stack<int>(secondLine);

        for (int i = 0; i < elementsToPop; i++)
        {
            stack.Pop();
        }

        if (stack.Count == 0) Console.WriteLine("0");

        else if (stack.Contains(hasElement)) Console.WriteLine("true");

        else Console.WriteLine(stack.Min());
    }
}
