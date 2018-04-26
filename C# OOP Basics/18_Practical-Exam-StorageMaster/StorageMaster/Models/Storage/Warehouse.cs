using System.Collections.Generic;
using StorageMaster.Models.Vehicles;

namespace StorageMaster.Models.Storage
{
    public class Warehouse : Storage
    {
        public Warehouse(string name) : base(name, 10, 10, new List<Vehicle>(){new Semi(), new Semi(), new Semi()})
        {
        }
    }
}
