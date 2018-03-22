using System;
using System.Linq;

public class Engine
{
    private CustomList<string> list;

    public void ExecuteCommands()
    {
        list = new CustomList<string>();

        while (true)
        {
            var input = Console.ReadLine();
            if (input.Equals("END")) break;

            var args = input.Split().ToList();
            string command = args[0];

            switch (command)
            {
                case "Add":
                    list.Add(args[1]);
                    break;
                case "Remove":
                    list.Remove(int.Parse(args[1]));
                    break;
                case "Contains":
                    Console.WriteLine(list.Contains(args[1]));
                    break;
                case "Swap":
                    int index1 = int.Parse(args[1]);
                    int index2 = int.Parse(args[2]);
                    list.Swap(index1, index2);
                    break;
                case "Greater":
                    Console.WriteLine(list.CountGreaterThan(args[1]));
                    break;
                case "Max":
                    Console.WriteLine(list.Max());
                    break;
                case "Min":
                    Console.WriteLine(list.Min());
                    break;
                case "Sort":
                    list.Sort();
                    break;
                case "Print":
                    list.PrintAllElements();
                    break;
            }
        }
    }
}
