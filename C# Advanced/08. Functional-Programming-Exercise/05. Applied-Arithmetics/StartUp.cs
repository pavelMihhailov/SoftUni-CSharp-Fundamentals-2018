using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        IEnumerable<int> numbers = Console.ReadLine().Split().Select(int.Parse);

        Func<int, int> add = num => num + 1;
        Func<int, int> subtract = num => num - 1;
        Func<int, int> multiply = num => num * 2;

        while (true)
        {
            string command = Console.ReadLine();
            if (command == "end") break;

            if (command == "add") numbers = Foreach(numbers, add);
            else if (command == "subtract") numbers = Foreach(numbers, subtract);
            else if (command == "multiply") numbers = Foreach(numbers, multiply);
            else Console.WriteLine(string.Join(" ", numbers));
        }
        
    }
    public static IEnumerable<int> Foreach(IEnumerable<int> numbers, Func<int, int> function)
    {
        return numbers.Select(n => function(n));
    }
}
