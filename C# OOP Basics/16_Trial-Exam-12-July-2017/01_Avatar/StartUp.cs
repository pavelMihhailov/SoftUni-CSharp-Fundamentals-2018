using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        NationsBuilder nationsBuilder = new NationsBuilder();

        while (true)
        {
            List<string> input = new List<string>(Console.ReadLine().Split().ToList());
            ParseCommand.ExecuteCommand(input, nationsBuilder);
            if (input[0] == "Quit") break;
        }
    }
}
