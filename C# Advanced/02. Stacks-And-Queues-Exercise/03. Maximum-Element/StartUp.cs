using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Stack<int> resultStack = new Stack<int>();

        for (int i = 0; i < n; i++)
        {
            int[] command = Console.ReadLine().Split().Select(int.Parse).ToArray();

            if (command.Length == 1)
            {
                if (command[0] == 2) resultStack.Pop();
                if (command[0] == 3) Console.WriteLine(resultStack.Max());
            }
            else resultStack.Push(command[1]);
        }
    }
}
