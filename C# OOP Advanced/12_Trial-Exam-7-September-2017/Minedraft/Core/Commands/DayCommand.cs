using System;
using System.Collections.Generic;

public class DayCommand : Command
{
    private IHarvesterController harvesterController;
    private IProviderController providerController;

    public DayCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController) : base(arguments)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {
        string energyProducedToday = this.providerController.Produce();
        string oreProducedToday = this.harvesterController.Produce();

        return energyProducedToday + Environment.NewLine + oreProducedToday;
    }
}