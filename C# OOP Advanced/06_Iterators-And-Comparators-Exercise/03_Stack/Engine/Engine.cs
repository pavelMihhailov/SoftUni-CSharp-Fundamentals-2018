using System;
using System.Linq;

public class Engine
{
    public void Run()
    {
        var command = Console.ReadLine().Split(" ,".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        var stack = new Stack<int>();

        while (!command[0].Equals("END"))
        {
            if (command[0].Equals("Push"))
            {
                var args = command.Skip(1).ToList();
                for (int i = 0; i < args.Count; i++)
                {
                    stack.Push(int.Parse(args[i]));
                }
            }
            else if (command[0].Equals("Pop"))
            {
                try
                {
                    stack.Pop();
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }

            command = Console.ReadLine().Split(" ,".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        }

        Console.WriteLine(string.Join("\n", stack));
        Console.WriteLine(string.Join("\n", stack));
    }
}