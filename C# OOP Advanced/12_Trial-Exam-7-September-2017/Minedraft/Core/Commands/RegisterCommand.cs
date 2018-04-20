using System.Collections.Generic;
using System.Linq;

public class RegisterCommand : Command
{
    private IHarvesterController harvesterController;
    private IProviderController providerController;

    public RegisterCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController) : base(arguments)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {
        var typeToRegister = Arguments[0];

        var skipedArgs = Arguments.Skip(1).ToList();

        if (typeToRegister.Equals(nameof(Harvester)))
        {
            return this.harvesterController.Register(skipedArgs);
        }
        if (typeToRegister.Equals(nameof(Provider)))
        {
            return this.providerController.Register(skipedArgs);
        }

        return Constants.InvalidEntityToRegister;
    }
}