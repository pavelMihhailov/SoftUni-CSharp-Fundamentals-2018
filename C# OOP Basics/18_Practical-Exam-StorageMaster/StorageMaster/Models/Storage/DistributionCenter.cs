using System.Collections.Generic;
using StorageMaster.Models.Vehicles;

namespace StorageMaster.Models.Storage
{
    public class DistributionCenter : Storage
    {
        public DistributionCenter(string name) 
            : base(name, 2, 5, new List<Vehicle>{new Van(), new Van(), new Van()})
        {
        }
    }
}
