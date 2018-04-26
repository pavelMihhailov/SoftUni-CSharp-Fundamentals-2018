using System;
using StorageMaster.Models.Products;

namespace StorageMaster.Factories
{
    public class ProductFactory
    {
        public Product CreateProduct(string type, double price)
        {
            Product product;

            switch (type)
            {
                case "Gpu":
                    product = new Gpu(price);
                    break;
                case "HardDrive":
                    product = new HardDrive(price);
                    break;
                case "Ram":
                    product = new Ram(price);
                    break;
                case "SolidStateDrive":
                    product = new SolidStateDrive(price);
                    break;
                default:
                    throw new InvalidOperationException("Invalid product type!");
            }

            return product;
        }
    }
}
