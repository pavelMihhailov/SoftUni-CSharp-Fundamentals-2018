using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        List<Customer> customers = new List<Customer>();

        AddBuyers(customers);
        BuyFood(customers);

        int total = customers.Sum(x => x.Food);
        Console.WriteLine(total);
    }

    private static void BuyFood(List<Customer> customers)
    {
        while (true)
        {
            string name = Console.ReadLine();
            if (name == "End") break;

            foreach (var customer in customers)
                if (customer.Name.Equals(name)) customer.BuyFood(customer);
        }
    }

    private static void AddBuyers(List<Customer> customers)
    {
        int lines = int.Parse(Console.ReadLine());

        for (int i = 0; i < lines; i++)
        {
            string[] args = Console.ReadLine().Split();

            string name = args[0];
            int age = int.Parse(args[1]);
            if (args.Length == 3)
            {
                string group = args[2];
                Rebel rebel = new Rebel(name, age, group);
                customers.Add(rebel);
            }
            else
            {
                string id = args[2];
                string birthdate = args[3];
                Citizen citizen = new Citizen(name, age, id, birthdate);
                customers.Add(citizen);
            }
        }
    }
}
