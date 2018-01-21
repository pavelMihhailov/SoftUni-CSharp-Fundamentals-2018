using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        List<string> names = Console.ReadLine().Split().ToList();

        while (true)
        {
            string[] command = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            if (command[0] == "Party!") break;

            switch (command[1])
            {
                case "StartsWith": Foreach(names, command[0], n => n.StartsWith($"{command[2]}"));
                    break;
                case "EndsWith": Foreach(names, command[0], n => n.EndsWith($"{command[2]}"));
                    break;
                case "Length": Foreach(names, command[0], n => n.Length == int.Parse(command[2]));
                    break;
            }
        }
        if (names.Count == 0) Console.WriteLine("Nobody is going to the party!");
        else Console.WriteLine($"{string.Join(", ", names)} are going to the party!");
    }

    public static void Foreach(List<string> names, string command, Func<string, bool> requirement)
    {
        for (int i = names.Count - 1; i >= 0; i--)
        {
            if (requirement(names[i]))
            {
                switch (command)
                {
                    case "Remove": names.RemoveAt(i);
                        break;
                    case "Double": names.Add(names[i]);
                        break;
                }
            }
        }
    }
}
