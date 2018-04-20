using System.Collections;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        IReader reader = new Reader();
        IWriter writer = new Writer();

        IHarvesterFactory harvesterFactory = new HarvesterFactory();

        IEnergyRepository energyRepository = new EnergyRepository();
        
        IHarvesterController harvesterController =
            new HarvesterController(energyRepository, new List<IHarvester>(), harvesterFactory);
        IProviderController providerController = new ProviderController(energyRepository);

        ICommandInterpreter commandInterpreter = new CommandInterpreter(harvesterController, providerController);

        Engine engine = new Engine(reader, writer, commandInterpreter);
        engine.Run();
    }
}