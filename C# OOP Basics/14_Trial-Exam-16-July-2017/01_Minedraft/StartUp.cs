using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        DraftManager manager = new DraftManager();
        while (true)
        {
            List<string> input = Console.ReadLine().Split().ToList();

            ExecuteCommands.ExecuteCommand(input, manager);
            if (input[0].Equals("Shutdown")) break;
        }
    }
}
