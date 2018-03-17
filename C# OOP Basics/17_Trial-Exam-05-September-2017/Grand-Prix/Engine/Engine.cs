using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    public static void StartRace(RaceTower raceTower)
    {
        int numberOfLaps = int.Parse(Console.ReadLine());
        int lengthOfTrack = int.Parse(Console.ReadLine());

        raceTower.SetTrackInfo(numberOfLaps, lengthOfTrack);

        while (!raceTower.endOfRace)
        {
            List<string> args = Console.ReadLine().Split().ToList();
            try
            {
                string command = args[0];
                List<string> arguments = args.Skip(1).ToList();

                switch (command)
                {
                    case "RegisterDriver":
                        raceTower.RegisterDriver(arguments);
                        break;
                    case "Leaderboard":
                        Console.WriteLine(raceTower.GetLeaderboard());
                        break;
                    case "CompleteLaps":
                        string result = raceTower.CompleteLaps(arguments);
                        if (result.Length != 0) Console.WriteLine(result);
                        break;
                    case "Box":
                        raceTower.DriverBoxes(arguments);
                        break;
                    case "ChangeWeather":
                        raceTower.ChangeWeather(arguments);
                        break;
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}