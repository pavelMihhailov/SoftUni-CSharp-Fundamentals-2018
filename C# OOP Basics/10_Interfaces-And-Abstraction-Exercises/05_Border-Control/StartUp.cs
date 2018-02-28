using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        List<IId> refugees = new List<IId>();

        while (true)
        {
            string[] line = Console.ReadLine().Split();
            if (line[0] == "End") break;

            if (line.Length == 2)
            {
                Robot robot = new Robot(line[0], line[1]);
                refugees.Add(robot);
            }
            else
            {
                Citizen citizen = new Citizen(line[0], int.Parse(line[1]), line[2]);
                refugees.Add(citizen);
            }
        }
        string fakeIds = Console.ReadLine();
        refugees.RemoveAll(x => !x.Id.EndsWith(fakeIds));
        refugees.ForEach(x => Console.WriteLine(x.Id));
    }
}
