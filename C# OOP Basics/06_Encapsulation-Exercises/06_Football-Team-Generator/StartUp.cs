using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        List<Team> teamList = new List<Team>();

        while (true)
        {
            string[] line = Console.ReadLine().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            if (line[0] == "END") break;

            if (line.Length < 2) continue;
            try
            {
                ExecuteCommands(teamList, line);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    private static void ExecuteCommands(List<Team> teamList, string[] line)
    {
        if (line[0] == "Team")
        {
            Team newTeam = new Team(line[1]);
            teamList.Add(newTeam);
        }
        Team team = teamList.FirstOrDefault(x => x.Name.Equals(line[1]));
        if (team == null) throw new ArgumentException($"Team {line[1]} does not exist.");

        if (line[0] == "Rating")
        {
            if (team.Name.Equals(line[1]))
            {
                Console.WriteLine(team.ToString());
            }
            else
                throw new ArgumentException("Team [team name] does not exist.");
        }

        else if (line[0] == "Remove")
        {
            //Remove
            string playerName = line[2];
            team.RemovePlayer(playerName);
        }
        else if (line[0] == "Add")
        {
            string playerName = line[2];
            int endurance = int.Parse(line[3]);
            int sprint = int.Parse(line[4]);
            int dribble = int.Parse(line[5]);
            int passing = int.Parse(line[6]);
            int shooting = int.Parse(line[7]);

            int[] stats = { endurance, sprint, dribble, passing, shooting };
            Player player = new Player(playerName, stats);
            team.AddPlayer(player);
        }
    }
}
