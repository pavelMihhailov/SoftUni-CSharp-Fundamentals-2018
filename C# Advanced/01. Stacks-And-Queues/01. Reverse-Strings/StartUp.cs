using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        string input = Console.ReadLine();

        Stack<string> reversedInput = new Stack<string>();

        for (int i = 0; i < input.Length; i++)
        {
            reversedInput.Push(input[i].ToString());
        }
        Console.WriteLine(string.Join("", reversedInput));
    }
}

