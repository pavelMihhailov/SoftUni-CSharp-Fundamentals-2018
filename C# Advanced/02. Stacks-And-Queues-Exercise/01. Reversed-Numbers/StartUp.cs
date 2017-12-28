using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        string[] input = Console.ReadLine().Split();
        Stack<string> reversedInput = new Stack<string>(input);

        Console.WriteLine(string.Join(" ", reversedInput));
    }
}
