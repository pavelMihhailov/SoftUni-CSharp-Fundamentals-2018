using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        string input = Console.ReadLine();
        Stack<int> stack = new Stack<int>();

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == '(') stack.Push(i);
            if (input[i] == ')')
            {
                int startIndex = stack.Pop();
                int endIndex = i;
                Console.WriteLine(input.Substring(startIndex, endIndex - startIndex + 1));
            }
        }
    }
}
