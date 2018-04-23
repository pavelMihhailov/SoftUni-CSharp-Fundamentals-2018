using System;
using System.Linq;
using System.Reflection;

namespace FestivalManager.Entities.Factories
{
	using Contracts;
	using Entities.Contracts;

	public class SetFactory : ISetFactory
	{
	    public ISet CreateSet(string name, string type)
	    {
	        Type convertedType = Assembly.GetCallingAssembly().GetTypes().Single(x => x.Name.Equals(type));

	        return (ISet)Activator.CreateInstance(convertedType, name);
	    }
	}
}
