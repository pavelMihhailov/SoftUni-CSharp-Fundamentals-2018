using System;
using System.Linq;

public class Engine
{
    public void Run()
    {
        var command = Console.ReadLine();

        var listyIterator = new ListyIterator<string>(command.Split().Skip(1));

        while (!(command = Console.ReadLine()).Equals("END"))
        {
            ExecuteCommand(command, listyIterator);
        }
    }

    private static void ExecuteCommand(string command, ListyIterator<string> listyIterator)
    {
        switch (command)
        {
            case "Move":
                Console.WriteLine(listyIterator.Move());
                break;
            case "Print":
                try
                {
                    listyIterator.Print();
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
                break;
            case "HasNext":
                Console.WriteLine(listyIterator.HasNext());
                break;
            case "PrintAll":
                listyIterator.PrintAll();
                break;
        }
    }
}