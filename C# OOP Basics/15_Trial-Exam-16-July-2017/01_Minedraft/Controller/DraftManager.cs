using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager
{
    public DraftManager()
    {
        totalMinedOre = 0;
        totalStoredEnergy = 0;
        mode = "Full";
        providers = new Dictionary<string, Provider>();
        harvesters = new Dictionary<string, Harvester>();
    }

    private Dictionary<string, Harvester> harvesters;

    private Dictionary<string, Provider> providers;

    private double totalStoredEnergy;

    private double totalMinedOre;

    private string mode;

    public string RegisterHarvester(List<string> arguments)
    {
        try
        {
            Harvester harvester = HarvesterFactory.CreateHarvester(arguments);
            harvesters[arguments[1]] = harvester;
            return $"Successfully registered {arguments[0]} Harvester - {harvester.Id}";
        }
        catch (ArgumentException e)
        {
            return e.Message;
        }
    }
    public string RegisterProvider(List<string> arguments)
    {
        string type = arguments[0];
        string id = arguments[1];

        try
        {
            Provider provider = ProviderFactory.CreateProvider(arguments);
            providers[id] = provider;
            return $"Successfully registered {type} Provider - {provider.Id}";
        }
        catch (ArgumentException e)
        {
            return e.Message;
        }
    }
    public string Day()
    {
        double allEnergy = providers.Values.Sum(x => x.EnergyOutput);
        totalStoredEnergy += allEnergy;
        double neededEnergy = harvesters.Values.Sum(x => x.EnergyRequirement);
        double totalOreOutput = harvesters.Values.Sum(x => x.OreOutput);

        ApplyMode(ref neededEnergy, ref totalOreOutput);

        double oreMinedPrivate = 0d;
        if (totalStoredEnergy >= neededEnergy)
        {
            oreMinedPrivate += totalOreOutput;
            totalMinedOre += totalOreOutput;
            totalStoredEnergy -= neededEnergy;
        }

        StringBuilder sb = new StringBuilder();
        sb.AppendLine("A day has passed.")
            .AppendLine($"Energy Provided: {allEnergy}")
            .AppendLine($"Plumbus Ore Mined: {oreMinedPrivate}");

        return sb.ToString().Trim();
    }

    public string Check(List<string> arguments)
    {
        string id = arguments[0];

        if (providers.ContainsKey(id)) return providers[id].ToString();
        if (harvesters.ContainsKey(id)) return harvesters[id].ToString();
        return $"No element found with id - {id}";
        
    }
    public string ShutDown()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("System Shutdown")
            .AppendLine($"Total Energy Stored: {totalStoredEnergy}")
            .AppendLine($"Total Mined Plumbus Ore: {totalMinedOre}");

        return sb.ToString().TrimEnd();
    }

    public string Mode(List<string> arguments)
    {
        string mode = arguments[0];
        this.mode = mode;
        return $"Successfully changed working mode to {mode} Mode";
    }

    private void ApplyMode(ref double neededEnergy, ref double totalOreOutput)
    {
        if (mode.Equals("Half"))
        {
            neededEnergy *= 0.6;
            totalOreOutput *= 0.5;
        }
        else if (mode.Equals("Energy"))
        {
            neededEnergy = 0;
            totalOreOutput = 0;
        }
    }
}
