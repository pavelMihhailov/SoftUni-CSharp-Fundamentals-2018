using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        List<Animal> animals = new List<Animal>();

        Animal currAnimal = null;

        int line = 0;
        while (true)
        {
            string[] info = Console.ReadLine().Split();
            if (info[0] == "End") break;


            if (line % 2 == 0)
            {
                currAnimal = GetAnimalInfo(currAnimal, info);
            }

            else
            {
                currAnimal.ProduceSound();

                Food food = GetFoodInfo(info);

                try
                {
                    currAnimal.Eat(food);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                animals.Add(currAnimal);
            }
            line++;
        }

        foreach (var animal in animals)
        {
            Console.WriteLine(animal.ToString());
        }
    }

    private static Food GetFoodInfo(string[] info)
    {
        string foodType = info[0];
        int quantity = int.Parse(info[1]);

        Food food = null;

        if (foodType.Equals("Vegetable")) food = new Vegetable(quantity);
        else if (foodType.Equals("Fruit")) food = new Fruit(quantity);
        else if (foodType.Equals("Meat")) food = new Meat(quantity);
        else if (foodType.Equals("Seeds")) food = new Seeds(quantity);
        return food;
    }

    private static Animal GetAnimalInfo(Animal currAnimal, string[] info)
    {
        string typeAnimal = info[0];
        string name = info[1];
        double weight = double.Parse(info[2]);
        string livingRegion = info[3];

        switch (typeAnimal)
        {
            case "Owl":
                currAnimal = new Owl(name, weight, double.Parse(info[3]));
                break;
            case "Hen":
                currAnimal = new Hen(name, weight, double.Parse(info[3]));
                break;
            case "Mouse":
                currAnimal = new Mouse(name, weight, livingRegion);
                break;
            case "Dog":
                currAnimal = new Dog(name, weight, livingRegion);
                break;
            case "Cat":
                currAnimal = new Cat(name, weight, livingRegion, info[4]);
                break;
            case "Tiger":
                currAnimal = new Tiger(name, weight, livingRegion, info[4]);
                break;
        }

        return currAnimal;
    }
}