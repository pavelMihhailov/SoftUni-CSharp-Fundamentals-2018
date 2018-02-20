using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        List<Person> personList = new List<Person>();
        List<Product> products = new List<Product>();

        try
        {
            ReadAndAddPeople(personList);
            ReadAndAddProducts(products);

            StartShop(personList, products);

            Print(personList);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }
    }

    private static void Print(List<Person> personList)
    {
        foreach (var person in personList)
        {
            Console.WriteLine(person.ToString());
        }
    }

    private static void StartShop(List<Person> personList, List<Product> products)
    {
        while (true)
        {
            string[] command = Console.ReadLine().Split();
            if (command[0] == "END") break;

            string name = command[0];
            string product = command[1];
            int personIndex = personList.FindIndex(x => x.Name.Equals(name));
            int productIndex = products.FindIndex(x => x.Name.Equals(product));

            if (products[productIndex].Cost > personList[personIndex].Money)
            {
                Console.WriteLine($"{name} can't afford {product}");
            }
            else
            {
                Console.WriteLine($"{name} bought {product}");
                personList[personIndex].Products.Add(products[productIndex]);
                personList[personIndex].Money -= products[productIndex].Cost;
            }
        }
    }

    private static void ReadAndAddProducts(List<Product> products)
    {
        string[] infoProducts = Console.ReadLine().Split(";=".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();
        for (int i = 0; i < infoProducts.Length; i += 2)
        {
            Product product = new Product(infoProducts[i], decimal.Parse(infoProducts[i + 1]));
            products.Add(product);
        }
    }

    private static void ReadAndAddPeople(List<Person> personList)
    {
        string[] infoPersons = Console.ReadLine().Split(";=".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();

        for (int i = 0; i < infoPersons.Length; i += 2)
        {
            Person person = new Person(infoPersons[i], decimal.Parse(infoPersons[i + 1]));
            personList.Add(person);
        }
    }
}
