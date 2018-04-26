using System.Collections.Generic;
using StorageMaster.Models.Vehicles;

namespace StorageMaster.Models.Storage
{
    public class AutomatedWarehouse : Storage
    {
        public AutomatedWarehouse(string name) : base(name, 1, 2, new List<Vehicle> {new Truck()})
        {
        }
    }
}
