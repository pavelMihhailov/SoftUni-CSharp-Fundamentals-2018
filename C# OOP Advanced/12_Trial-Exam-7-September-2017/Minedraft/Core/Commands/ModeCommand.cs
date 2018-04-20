using System.Collections.Generic;

public class ModeCommand : Command
{
    private IHarvesterController harvesterController;

    public ModeCommand(IList<string> arguments, IHarvesterController harvesterController) : base(arguments)
    {
        this.harvesterController = harvesterController;
    }

    public override string Execute()
    {
        string result = this.harvesterController.ChangeMode(this.Arguments[0]);

        return result;
    }
}
