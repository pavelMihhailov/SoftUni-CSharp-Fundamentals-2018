using System.Collections.Generic;
using System.Linq;

public class HarvesterController : IHarvesterController
{
    private const double HalfModeEnergyRequirement = 50;
    private const double EnergyModeEnergyRequirement = 20;
    private const int MinDurability = 0;

    private IList<IHarvester> harvesters;
    private IEnergyRepository energyRepository;
    private IHarvesterFactory factory;
    private string mode;

    public HarvesterController(IEnergyRepository energyRepository, IList<IHarvester> harvesters, IHarvesterFactory harvesterFactory)
    {
        this.energyRepository = energyRepository;
        this.harvesters = harvesters;
        this.factory = harvesterFactory;
        this.mode = "Full";
        this.OreProduced = 0;
    }

    public IReadOnlyCollection<IEntity> Entities => this.harvesters.ToList().AsReadOnly();

    public string Register(IList<string> args)
    {
        IHarvester harvester = this.factory.GenerateHarvester(args);
        harvesters.Add(harvester);

        return string.Format(Constants.SuccessfullRegistration, harvester.GetType().Name);
    }

    public string Produce()
    {
        double neededEnergy = 0;

        foreach (var harvester in harvesters)
        {
            if (this.mode == "Full") neededEnergy += harvester.EnergyRequirement;
            else if (this.mode == "Half") neededEnergy += harvester.EnergyRequirement * HalfModeEnergyRequirement / 100;
            else if (this.mode == "Energy") neededEnergy += harvester.EnergyRequirement * EnergyModeEnergyRequirement / 100;
        }

        double minedOres = 0;

        if (this.energyRepository.EnergyStored >= neededEnergy)
        {
            this.energyRepository.TakeEnergy(neededEnergy);

            foreach (var harvester in harvesters)
            {
                minedOres += harvester.Produce();
            }

            if (this.mode == "Energy")
            {
                minedOres *= EnergyModeEnergyRequirement / 100;
            }
            if (this.mode == "Half")
            {
                minedOres *= HalfModeEnergyRequirement / 100;
            }

            this.OreProduced += minedOres;
        }

        return string.Format(Constants.OreOutputToday, minedOres);
    }

    public double OreProduced { get; private set; }

    public string ChangeMode(string mode)
    {
        this.mode = mode;

        foreach (var harvester in harvesters)
        {
            harvester.Broke();
        }

        this.harvesters = this.harvesters.Where(x => x.Durability >= MinDurability).ToList();

        return string.Format(Constants.ModeChanged, this.mode);
    }
}
