namespace FestivalManager.Entities.Factories
{
	using System;
	using System.Linq;
	using System.Reflection;
	using Contracts;
	using Entities.Contracts;

	public class InstrumentFactory : IInstrumentFactory
	{
	    public IInstrument CreateInstrument(string type)
	    {
	        Type convertedType = Assembly.GetCallingAssembly().GetTypes().Single(x => x.Name.Equals(type));

	        return (IInstrument) Activator.CreateInstance(convertedType);
	    }
	}
}