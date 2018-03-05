using System.Collections.Generic;

public class HarvesterFactory
{
    public static Harvester CreateHarvester(List<string> args)
    {
        string type = args[0];
        string id = args[1];
        double oreOutput = double.Parse(args[2]);
        double energyRequirement = double.Parse(args[3]);

        if (type.Equals("Hammer")) return new HammerHarvester(id, oreOutput, energyRequirement);

        int sonicFactor = int.Parse(args[4]);
        return new SonicHarvester(id, oreOutput, energyRequirement, sonicFactor);
    }
}
