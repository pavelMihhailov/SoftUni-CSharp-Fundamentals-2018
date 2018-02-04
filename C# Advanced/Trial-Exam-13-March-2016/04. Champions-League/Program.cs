using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Champions_League
{
    class Program
    {
        public class Team
        {
            public string Name { get; set; }
            public int Wins { get; set; }
            public List<string> Opponents { get; set; }
        }

        static void Main(string[] args)
        {
            string[] line = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);
            
            List<Team> listOfTeams = new List<Team>();

            while (true)
            {
                if (line[0] == "stop") break;
                string team1 = line[0].Trim();
                string team2 = line[1].Trim();
                int[] firstResult = line[2].Split(':').Select(int.Parse).ToArray();
                int[] secondResult = line[3].Split(':').Select(int.Parse).ToArray();

                //check the results
                int totalGoalsTeam1 = firstResult[0];
                totalGoalsTeam1 += secondResult[1];
                int totalGoalsTeam2 = firstResult[1];
                totalGoalsTeam2 += secondResult[0];
                //team1 win
                if (totalGoalsTeam1 > totalGoalsTeam2) AddInfo(listOfTeams, team1, team2);
                //team2 win
                else if (totalGoalsTeam2 > totalGoalsTeam1) AddInfo(listOfTeams, team2, team1);
                //draw
                else
                {
                    int awayGoalsTeam1 = secondResult[1];
                    int awayGoalsTeam2 = firstResult[1];

                    if (awayGoalsTeam1 > awayGoalsTeam2) AddInfo(listOfTeams, team1, team2);
                    else AddInfo(listOfTeams, team2, team1);
                }

                line = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);
            }
            //Print
            foreach (var teamInfo in listOfTeams.OrderByDescending(x => x.Wins).ThenBy(x => x.Name))
            {
                Console.WriteLine(teamInfo.Name);
                Console.WriteLine($"- Wins: {teamInfo.Wins}");
                Console.WriteLine($"- Opponents: {string.Join(", ", teamInfo.Opponents.OrderBy(x => x))}");
            }
        }

        private static void AddInfo(List<Team> listOfTeams, string team1, string team2)
        {
            Team firstTeam = new Team();
            firstTeam.Name = team1;
            firstTeam.Wins += 1;
            firstTeam.Opponents = new List<string>();
            firstTeam.Opponents.Add(team2);

            Team secondTeam = new Team();
            secondTeam.Name = team2;
            secondTeam.Wins = 0;
            secondTeam.Opponents = new List<string>();
            secondTeam.Opponents.Add(team1);

            bool hasFirstTeam = false;
            bool hasSecondTeam = false;
            int indexOfTeam1 = -1;
            int indexOfTeam2 = -1;
            for (int i = 0; i < listOfTeams.Count; i++)
            {
                if (listOfTeams[i].Name == team1)
                {
                    hasFirstTeam = true;
                    indexOfTeam1 = i;
                }
                if (listOfTeams[i].Name == team2)
                {
                    hasSecondTeam = true;
                    indexOfTeam2 = i;
                }
            }
            //add info team1
            if (!hasFirstTeam) listOfTeams.Add(firstTeam);
            else
            {
                listOfTeams[indexOfTeam1].Wins++;
                //add opponent if not exist
                if (!listOfTeams[indexOfTeam1].Opponents.Contains(team2)) listOfTeams[indexOfTeam1].Opponents.Add(team2);
            }
            //add info team2
            if (!hasSecondTeam) listOfTeams.Add(secondTeam);
            else
            {
                if (!listOfTeams[indexOfTeam2].Opponents.Contains(team1)) listOfTeams[indexOfTeam2].Opponents.Add(team1);
            }
        }
    }
}
