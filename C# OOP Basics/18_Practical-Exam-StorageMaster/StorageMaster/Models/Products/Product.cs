using System;

namespace StorageMaster.Models.Products
{
    public abstract class Product
    {
        private double price;

        protected Product(double price, double weight)
        {
            Price = price;
            Weight = weight;
        }

        public double Price
        {
            get => this.price;
            protected set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException("Price cannot be negative!");
                }
                this.price = value;
            }
        }

        public double Weight { get; }
    }
}
