using System;
using System.Linq;

namespace StorageMaster.Core
{
    public class Engine
    {
        public void Run()
        {
            StorageMaster storageMaster = new StorageMaster();

            while (true)
            {
                var input = Console.ReadLine().Split();
                string command = input[0];

                if (command.Equals("END")) break;

                string result = null;

                try
                {
                    switch (command)
                    {
                        case "AddProduct":
                            result = storageMaster.AddProduct(input[1], double.Parse(input[2]));
                            break;
                        case "RegisterStorage":
                            result = storageMaster.RegisterStorage(input[1], input[2]);
                            break;
                        case "SelectVehicle":
                            result = storageMaster.SelectVehicle(input[1], int.Parse(input[2]));
                            break;
                        case "LoadVehicle":
                            result = storageMaster.LoadVehicle(input.Skip(1).ToList());
                            break;
                        case "SendVehicleTo":
                            result = storageMaster.SendVehicleTo(input[1], int.Parse(input[2]), input[3]);
                            break;
                        case "UnloadVehicle":
                            result = storageMaster.UnloadVehicle(input[1], int.Parse(input[2]));
                            break;
                        case "GetStorageStatus":
                            result = storageMaster.GetStorageStatus(input[1]);
                            break;
                    }
                }
                catch (InvalidOperationException e)
                {
                    result = "Error: " + e.Message;
                }
                Console.WriteLine(result);
            }
            Console.WriteLine(storageMaster.GetSummary());
        }
    }
}
