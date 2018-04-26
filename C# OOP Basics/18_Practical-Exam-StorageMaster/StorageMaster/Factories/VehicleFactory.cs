using System;
using StorageMaster.Models.Vehicles;

namespace StorageMaster.Factories
{
    public class VehicleFactory
    {
        public Vehicle CreateVehicle(string type)
        {
            Vehicle vehicle = null;

            switch (type)
            {
                case "Semi":
                    vehicle = new Semi();
                    break;
                case "Truck":
                    vehicle = new Truck();
                    break;
                case "Van":
                    vehicle = new Van();
                    break;
                default:
                    throw new InvalidOperationException("Invalid vehicle type!");
            }

            return vehicle;
        }
    }
}
