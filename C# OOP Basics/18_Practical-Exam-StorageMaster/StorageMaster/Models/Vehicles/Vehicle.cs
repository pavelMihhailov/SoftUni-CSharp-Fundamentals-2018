using System;
using System.Collections.Generic;
using System.Linq;
using StorageMaster.Models.Products;

namespace StorageMaster.Models.Vehicles
{
    public abstract class Vehicle
    {
        private readonly List<Product> trunk;

        protected Vehicle(int capacity)
        {
            Capacity = capacity;
            this.trunk = new List<Product>();
        }

        public int Capacity { get; protected set; }

        public IReadOnlyCollection<Product> Trunk => this.trunk.AsReadOnly();

        public bool IsFull => this.trunk.Sum(x => x.Weight) >= Capacity;

        public bool IsEmpty => this.trunk.Count == 0;

        public void LoadProduct(Product product)
        {
            if (IsFull)
                throw new InvalidOperationException("Vehicle is full!");

            this.trunk.Add(product);
        }

        public Product Unload()
        {
            if (IsEmpty)
                throw new InvalidOperationException("No products left in vehicle!");

            Product product = this.trunk.Last();
            this.trunk.Remove(product);

            return product;
        }
    }
}
