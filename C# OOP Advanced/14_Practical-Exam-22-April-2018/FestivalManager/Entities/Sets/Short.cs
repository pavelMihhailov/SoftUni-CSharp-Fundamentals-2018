namespace FestivalManager.Entities.Sets
{
	using System;

	public class Short : Set
	{
		public Short(string name) 
			: base(name)
		{
		    MaxDuration = new TimeSpan(0, 15, 0);
		}
	}
}