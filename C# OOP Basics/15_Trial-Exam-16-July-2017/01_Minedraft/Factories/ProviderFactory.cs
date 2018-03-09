using System.Collections.Generic;

public class ProviderFactory
{
    public static Provider CreateProvider(List<string> args)
    {
        string type = args[0];
        string id = args[1];
        double energyOutput = double.Parse(args[2]);
        
        if (type.Equals("Solar")) return new SolarProvider(id, energyOutput);
        return new PressureProvider(id, energyOutput);
    }
}
