using System;
using System.Collections.Generic;
using System.Linq;

public class ExecuteCommands
{
    public static void ExecuteCommand(List<string> input, DraftManager manager)
    {
        string command = input[0];
        List<string> arguments = input.Skip(1).ToList();

        if (command.Equals("RegisterHarvester")) Console.WriteLine(manager.RegisterHarvester(arguments));
        else if (command.Equals("RegisterProvider")) Console.WriteLine(manager.RegisterProvider(arguments));
        else if (command.Equals("Day")) Console.WriteLine(manager.Day());
        else if (command.Equals("Mode")) Console.WriteLine(manager.Mode(arguments));
        else if (command.Equals("Check")) Console.WriteLine(manager.Check(arguments));
        else if (command.Equals("Shutdown")) Console.WriteLine(manager.ShutDown());
    }
}
