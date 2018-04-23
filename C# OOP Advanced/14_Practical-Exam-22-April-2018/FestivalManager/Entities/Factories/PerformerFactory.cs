namespace FestivalManager.Entities.Factories
{
	using Contracts;
	using Entities.Contracts;

	public class PerformerFactory : IPerformerFactory
	{
	    public IPerformer CreatePerformer(string name, int age)
	    {
	        return new Performer(name, age);
	    }
	}
}