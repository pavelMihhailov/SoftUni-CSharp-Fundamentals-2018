using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StorageMaster.Factories;
using StorageMaster.Models.Products;
using StorageMaster.Models.Storage;
using StorageMaster.Models.Vehicles;

namespace StorageMaster.Core
{
    public class StorageMaster
    {
        private List<Product> productsPool;
        private ProductFactory productFactory;
        private StorageFactory storageFactory;
        private List<Storage> storageRegistry;
        private Vehicle currentVehicle;

        public StorageMaster()
        {
            productsPool = new List<Product>();
            storageRegistry = new List<Storage>();
            productFactory = new ProductFactory();
            storageFactory = new StorageFactory();
        }

        public string AddProduct(string type, double price)
        {
            Product product = productFactory.CreateProduct(type, price);
            productsPool.Add(product);

            return $"Added {type} to pool";
        }

        public string RegisterStorage(string type, string name)
        {
            Storage storage = storageFactory.CreateStorage(type, name);
            storageRegistry.Add(storage);

            return $"Registered {name}";
        }

        public string SelectVehicle(string storageName, int garageSlot)
        {
            currentVehicle = storageRegistry.FirstOrDefault(x => x.Name.Equals(storageName))?.GetVehicle(garageSlot);

            return $"Selected {currentVehicle?.GetType().Name}";
        }

        public string LoadVehicle(IEnumerable<string> productNames)
        {
            int loadedProducts = 0;

            foreach (var productName in productNames)
            {
                if (!productsPool.Any(x => x.GetType().Name.Equals(productName)))
                    throw new InvalidOperationException($"{productName} is out of stock!");

                int indexOfProduct = productsPool.FindLastIndex(x => x.GetType().Name.Equals(productName));
                var productToAdd = productsPool[indexOfProduct];
                
                if (!currentVehicle.IsFull)
                {
                    productsPool.RemoveAt(indexOfProduct);
                    currentVehicle.LoadProduct(productToAdd);
                    loadedProducts++;
                }
            }

            int productsCount = 0;
            foreach (var name in productNames)
            {
                productsCount++;
            }

            return $"Loaded {loadedProducts}/{productsCount} products into {currentVehicle.GetType().Name}";
        }

        public string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName)
        {
            if (!storageRegistry.Any(x => x.Name.Equals(sourceName)))
                throw new InvalidOperationException("Invalid source storage!");
            if (!storageRegistry.Any(x => x.Name.Equals(destinationName)))
                throw new InvalidOperationException("Invalid destination storage!");
            
            Storage destinationStorage = storageRegistry.First(x => x.Name.Equals(destinationName));

            int destinationSlot = storageRegistry.First(x => x.Name.Equals(sourceName)).SendVehicleTo(sourceGarageSlot, destinationStorage);
            var vehicle = storageRegistry.First(x => x.Name.Equals(sourceName)).GetVehicle(sourceGarageSlot);
            storageRegistry.First(x => x.Name.Equals(sourceName)).RemoveVehicle(sourceGarageSlot);

            return $"Sent {vehicle.GetType().Name} to {destinationName} (slot {destinationSlot})";
        }

        public string UnloadVehicle(string storageName, int garageSlot)
        {
            int storageIndex = storageRegistry.FindIndex(x => x.Name.Equals(storageName));
            Vehicle vehicle = storageRegistry[storageIndex].GetVehicle(garageSlot);
            int trunkCount = vehicle.Trunk.Count;

            int unloadedProducts = storageRegistry[storageIndex].UnloadVehicle(garageSlot);

            return $"Unloaded {unloadedProducts}/{trunkCount} products at {storageName}";
        }

        public string GetStorageStatus(string storageName)
        {
            int storageIndex = storageRegistry.FindIndex(x => x.Name.Equals(storageName));
            var storage = storageRegistry[storageIndex];

            StringBuilder sb = new StringBuilder();

            Dictionary<string, int> orderedProducts = new Dictionary<string, int>();
            foreach (var product in storage.Products)
            {
                if (!orderedProducts.ContainsKey(product.GetType().Name))
                {
                    orderedProducts.Add(product.GetType().Name, 0);
                }
                orderedProducts[product.GetType().Name]++;
            }

            sb.Append($"Stock ({storage.Products.Sum(x => x.Weight)}/{storage.Capacity}): [");
            AppendStockInfo(sb, orderedProducts);

            sb.Append($"Garage: [");
            AppendGarageInfo(storage, sb);

            return sb.ToString().Trim();
        }

        public string GetSummary()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var storage in storageRegistry.OrderByDescending(x => x.Products.Sum(s => s.Price)))
            {
                double totalMoney = storage.Products.Sum(x => x.Price);

                sb.AppendLine($"{storage.Name}:")
                    .AppendLine($"Storage worth: ${totalMoney:f2}");
            }

            return sb.ToString().Trim();
        }

        private static void AppendGarageInfo(Storage storage, StringBuilder sb)
        {
            int counter = 0;
            bool last = false;
            foreach (var vehicle in storage.Garage)
            {
                counter++;
                if (storage.Garage.Count == counter) last = true;
                if (vehicle == null)
                {
                    sb.Append("empty");
                }
                else
                {
                    sb.Append(vehicle.GetType().Name);
                }
                if (!last) sb.Append("|");
                else sb.AppendLine("]");
            }
        }

        private static void AppendStockInfo(StringBuilder sb, Dictionary<string, int> orderedProducts)
        {
            int counter = 0;
            foreach (var product in orderedProducts.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                counter++;
                if (counter == orderedProducts.Count)
                {
                    sb.AppendLine($"{product.Key} ({product.Value})]");
                }
                else
                {
                    sb.Append($"{product.Key} ({product.Value}), ");
                }
            }
            if (counter == 0) sb.AppendLine("]");
        }
    }
}
