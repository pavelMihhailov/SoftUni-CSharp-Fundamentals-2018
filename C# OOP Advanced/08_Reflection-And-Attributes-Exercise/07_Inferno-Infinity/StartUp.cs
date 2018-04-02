using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    static void Main()
    {
        Controller controller = new Controller();

        while (true)
        {
            List<string> input = Console.ReadLine().Split(';').ToList();
            if (input[0].Equals("END")) break;

            controller.ExecuteCommands(input);
        }
    }
}
