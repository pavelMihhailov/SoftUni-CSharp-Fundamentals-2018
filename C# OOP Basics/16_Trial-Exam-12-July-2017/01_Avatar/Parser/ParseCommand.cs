using System;
using System.Collections.Generic;

public class ParseCommand
{
    public static void ExecuteCommand(List<string> input, NationsBuilder nationsBuilder)
    {
        string command = input[0];

        switch (command)
        {
            case "Bender":
                nationsBuilder.AssignBender(input);
                break;
            case "Monument":
                nationsBuilder.AssignMonument(input);
                break;
            case "Status":
                Console.WriteLine(nationsBuilder.GetStatus(input[1]));
                break;
            case "War":
                nationsBuilder.IssueWar(input[1]);
                break;
            case "Quit":
                Console.WriteLine(nationsBuilder.GetWarsRecord());
                break;
        }
    }
}
