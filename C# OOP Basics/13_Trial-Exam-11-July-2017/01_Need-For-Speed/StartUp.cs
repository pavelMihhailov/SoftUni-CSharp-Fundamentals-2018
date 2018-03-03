using System;

public class StartUp
{
    public static void Main()
    {
        CarManager carManager = new CarManager();
        while (true)
        {
            string command = Console.ReadLine();
            if (command.Equals("Cops Are Here")) break;

            ExecuteCommands(carManager, command);
        }
    }

    private static void ExecuteCommands(CarManager carManager, string command)
    {
        string[] action = command.Split();

        string cmd = action[0];
        if (cmd.Equals("register"))
        {
            int id = int.Parse(action[1]);
            string type = action[2];
            string brand = action[3];
            string model = action[4];
            int year = int.Parse(action[5]);
            int horsepower = int.Parse(action[6]);
            int acceleration = int.Parse(action[7]);
            int suspension = int.Parse(action[8]);
            int durability = int.Parse(action[9]);

            carManager.Register(id, type, brand, model, year, horsepower, acceleration, suspension, durability);
        }
        else if (cmd.Equals("open"))
        {
            int id = int.Parse(action[1]);
            string type = action[2];
            int length = int.Parse(action[3]);
            string route = action[4];
            int prizePool = int.Parse(action[5]);

            if (action.Length == 6) carManager.Open(id, type, length, route, prizePool);
            else carManager.Open(id, type, length, route, prizePool, int.Parse(action[6]));
        }
        else if (cmd.Equals("participate"))
        {
            carManager.Participate(int.Parse(action[1]), int.Parse(action[2]));
        }
        else if (cmd.Equals("check"))
        {
            Console.WriteLine(carManager.Check(int.Parse(action[1])));
        }
        else if (cmd.Equals("start"))
        {
            Console.WriteLine(carManager.Start(int.Parse(action[1])));
        }
        else if (cmd.Equals("park"))
        {
            carManager.Park(int.Parse(action[1]));
        }
        else if (cmd.Equals("unpark"))
        {
            carManager.Unpark(int.Parse(action[1]));
        }
        else if (cmd.Equals("tune"))
        {
            carManager.Tune(int.Parse(action[1]), action[2]);
        }
    }
}