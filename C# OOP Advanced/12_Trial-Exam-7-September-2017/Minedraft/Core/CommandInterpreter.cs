using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class CommandInterpreter : ICommandInterpreter
{
    private const string CommandSuffix = "Command";

    private IHarvesterController harvesterController;
    private IProviderController providerController;

    public CommandInterpreter(IHarvesterController harvesterController, IProviderController providerController)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public IHarvesterController HarvesterController => this.harvesterController;

    public IProviderController ProviderController => this.providerController;

    public string ProcessCommand(IList<string> args)
    {
        string command = args[0] + CommandSuffix;
        args = args.Skip(1).ToList();

        Type commandType = Assembly.GetExecutingAssembly()
            .GetTypes().FirstOrDefault(x => x.Name == command);

        object[] commandParams;

        if (command.Equals(nameof(ModeCommand)))
        {
            commandParams = new object[] { args, this.harvesterController};
        }
        else if (command.Equals(nameof(RepairCommand)))
        {
            commandParams = new object[] { args, this.providerController };
        }
        else
        {
            commandParams = new object[] { args, this.harvesterController, this.providerController };
        }
        

        ICommand commandForExecute = (ICommand) Activator.CreateInstance(commandType, commandParams);

        var result = commandForExecute.Execute();

        return result;
    }
}
