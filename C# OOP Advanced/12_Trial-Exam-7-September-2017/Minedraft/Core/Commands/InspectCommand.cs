using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class InspectCommand : Command
{
    private IHarvesterController harvesterController;
    private IProviderController providerController;

    public InspectCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController) : base(arguments)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {
        List<IEntity> entities = new List<IEntity>();
        GetHarvestersEntities(entities);
        GetProvidersEntities(entities);

        int id = int.Parse(Arguments[0]);

        foreach (var entity in entities)
        {
            if (entity.ID.Equals(id))
            {
                var type = entity.GetType().Name;
                var result = string.Format(Constants.EntityInfo, type, entity.Durability);

                return result;
            }
        }

        return string.Format(Constants.NoEntityFoundWithThatId, id);
    }

    private void GetHarvestersEntities(List<IEntity> entities)
    {
        var harvesterEntities = harvesterController.GetType()
            .GetProperties(BindingFlags.Instance | BindingFlags.Public)
            .FirstOrDefault(x => x.Name.Equals("Entities"));

        var harvesters =(IReadOnlyCollection<IEntity>) harvesterEntities.GetValue(this.harvesterController);

        entities.AddRange(harvesters);
    }

    private void GetProvidersEntities(List<IEntity> entities)
    {
        var providerEntities = providerController.GetType()
            .GetProperties(BindingFlags.Instance | BindingFlags.Public)
            .FirstOrDefault(x => x.Name.Equals("Entities"));

        var providers = (IReadOnlyCollection<IEntity>)providerEntities.GetValue(this.providerController);

        entities.AddRange(providers);
    }
}
