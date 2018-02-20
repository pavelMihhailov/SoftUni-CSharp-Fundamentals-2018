using System;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        Pizza pizza = new Pizza();
        MakePizza(pizza);
        Console.WriteLine(pizza.ToString());
    }

    private static void MakePizza(Pizza pizza)
    {
        while (true)
        {
            string[] line = Console.ReadLine().Split()
                .ToArray();
            if (line[0] == "END") break;

            string pizzaName = String.Empty;
            pizzaName = AddIngredients(pizza, line, pizzaName);

            try
            {
                pizza.NumberOfToppings++;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(0);
            }
        }
    }

    private static string AddIngredients(Pizza pizza, string[] line, string pizzaName)
    {
        if (line[0] == "Pizza")
        {
            pizzaName = line[1];
            try
            {
                pizza.Name = pizzaName;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(0);
            }
        }
        else if (line[0] == "Dough")
        {
            try
            {
                Dough dough = new Dough(line[1], line[2], double.Parse(line[3]));
                pizza.Dough = dough;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(0);
            }
        }
        else if (line[0] == "Topping")
        {
            try
            {
                Topping topping = new Topping(line[1], double.Parse(line[2]));
                pizza.AddTopping(topping);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(0);
            }
        }

        return pizzaName;
    }
}
