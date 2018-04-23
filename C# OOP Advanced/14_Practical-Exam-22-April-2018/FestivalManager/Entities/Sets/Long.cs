using System;

namespace FestivalManager.Entities.Sets
{
    public class Long : Set
    {
        public Long(string name) : base(name)
        {
            MaxDuration = new TimeSpan(0, 60, 0);
        }
    }
}
