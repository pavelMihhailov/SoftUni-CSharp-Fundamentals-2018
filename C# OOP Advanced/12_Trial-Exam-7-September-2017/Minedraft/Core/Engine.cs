using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private const string ShutdownCommand = "Shutdown";

    private IReader reader;
    private IWriter writer;
    private ICommandInterpreter commandInterpreter;

    public Engine(IReader reader, IWriter writer, ICommandInterpreter commandInterpreter)
    {
        this.reader = reader;
        this.writer = writer;
        this.commandInterpreter = commandInterpreter;
    }

    public void Run()
    {
        while (true)
        {
            var input = reader.ReadLine().TrimEnd();

            var data = input.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToList();

            var result = commandInterpreter.ProcessCommand(data);
            this.writer.WriteLine(result);

            if (input.Equals(ShutdownCommand, StringComparison.OrdinalIgnoreCase)) break;
        }
    }
}
