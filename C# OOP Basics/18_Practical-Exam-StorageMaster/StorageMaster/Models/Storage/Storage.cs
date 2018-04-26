using System;
using System.Collections.Generic;
using System.Linq;
using StorageMaster.Models.Products;
using StorageMaster.Models.Vehicles;

namespace StorageMaster.Models.Storage
{
    public abstract class Storage
    {
        private readonly List<Vehicle> garage;
        private readonly List<Product> products;

        protected Storage(string name, int capacity, int garageSlots, IEnumerable<Vehicle> vehicles)
        {
            Name = name;
            Capacity = capacity;
            GarageSlots = garageSlots;
            this.garage = new List<Vehicle>(vehicles);
            for (int i = vehicles.Count(); i < garageSlots; i++)
            {
                this.garage.Add(null);
            }
            this.products = new List<Product>();
        }

        public string Name { get; }

        //Max weight of products the storage can handle
        public int Capacity { get; protected set; }

        public int GarageSlots { get; protected set; }

        public IReadOnlyCollection<Vehicle> Garage => this.garage.AsReadOnly();

        public IReadOnlyCollection<Product> Products => this.products.AsReadOnly();

        public bool IsFull => this.products.Sum(x => x.Weight) >= Capacity;

        public Vehicle GetVehicle(int garageSlot)
        {
            if (garageSlot >= GarageSlots)
                throw new InvalidOperationException("Invalid garage slot!");
            if (this.garage[garageSlot] == null)
                throw new InvalidOperationException("No vehicle in this garage slot!");

            return this.garage[garageSlot];
        }

        public int SendVehicleTo(int garageSlot, Storage deliveryLocation)
        {
            var vehicle = GetVehicle(garageSlot);

            bool hasFreeSlot = false;
            int slotNumber = 0;

            for (int i = 0; i < deliveryLocation.Garage.Count; i++)
            {
                if (deliveryLocation.garage[i] == null)
                {
                    hasFreeSlot = true;
                    deliveryLocation.garage[i] = vehicle;
                    slotNumber = i;
                    break;
                }
            }
            if (!hasFreeSlot)
                throw new InvalidOperationException("No room in garage!");

            return slotNumber;
        }

        public int UnloadVehicle(int garageSlot)
        {
            if (this.IsFull)
                throw new InvalidOperationException("Storage is full!");

            int numberUnloadedProducts = 0;

            var vehicle = GetVehicle(garageSlot);

            while (!this.IsFull && !vehicle.IsEmpty)
            {
                this.products.Add(vehicle.Unload());
                numberUnloadedProducts++;
            }
            return numberUnloadedProducts;
        }

        public void RemoveVehicle(int index)
        {
            this.garage[index] = null;
        }
    }
}
