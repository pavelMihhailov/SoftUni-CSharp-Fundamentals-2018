using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static string corps;

    public static void Main()
    {
        List<ISoldier> soldiers = new List<ISoldier>();

        while (true)
        {
            string[] command = Console.ReadLine().Split();
            if (command[0].Equals("End")) break;

            string type = command[0];
            string id = command[1];
            string firstName = command[2];
            string lastName = command[3];
            decimal salary = decimal.Parse(command[4]);

            if (command.Length > 5) corps = command[5];

            AddSoldier(soldiers, command, type, id, firstName, lastName, salary);
        }
        foreach (var soldier in soldiers)
        {
            Console.WriteLine(soldier.ToString());
        }
    }

    private static void AddSoldier(List<ISoldier> soldiers, string[] command, string type, string id, string firstName, string lastName, decimal salary)
    {
        switch (type)
        {
            case "Private":
                soldiers.Add(new Private(id, firstName, lastName, salary));
                break;
            case "LeutenantGeneral":
                List<IPrivate> privates = GetPrivates(soldiers, command);
                soldiers.Add(new LeutenantGeneral(id, firstName, lastName, salary, privates));

                break;
            case "Engineer":
                if (ValidCorps(corps))
                {
                    List<IRepair> repairs = TakeRepairs(command);
                    soldiers.Add(new Engineer(id, firstName, lastName, salary, corps, repairs));
                }
                break;
            case "Commando":
                if (ValidCorps(corps))
                {
                    List<IMission> missions = GetMissions(command);
                    soldiers.Add(new Commando(id, firstName, lastName, salary, corps, missions));
                }
                break;
            case "Spy":
                soldiers.Add(new Spy(id, firstName, lastName, int.Parse(command[4])));
                break;
        }
    }

    private static List<IMission> GetMissions(string[] command)
    {
        List<IMission> missions = new List<IMission>();
        for (int i = 6; i <= command.Length - 1; i += 2)
        {
            string codeName = command[i];
            string state = command[i + 1];

            if (state.Equals("inProgress") || state.Equals("Finished"))
            {
                Mission mission = new Mission(codeName, state);
                missions.Add(mission);
            }
        }

        return missions;
    }

    private static List<IRepair> TakeRepairs(string[] command)
    {
        List<IRepair> repairs = new List<IRepair>();

        for (int i = 6; i <= command.Length - 1; i += 2)
        {
            Repair repair = new Repair(command[i], int.Parse(command[i + 1]));
            repairs.Add(repair);
        }

        return repairs;
    }

    private static List<IPrivate> GetPrivates(List<ISoldier> soldiers, string[] command)
    {
        List<IPrivate> privates = new List<IPrivate>();

        for (int i = 5; i <= command.Length - 1; i++)
        {
            string wantedId = command[i];
            privates.Add((IPrivate)soldiers.FirstOrDefault(x => x.Id.Equals(wantedId)));
        }

        return privates;
    }

    public static bool ValidCorps(string corps)
    {
        return corps == "Airforces" || corps == "Marines";
    }
}
