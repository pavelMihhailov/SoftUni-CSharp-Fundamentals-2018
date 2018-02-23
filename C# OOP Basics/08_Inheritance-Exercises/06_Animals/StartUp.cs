using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        List<Animal> animals = new List<Animal>();

        while (true)
        {
            string animalType = Console.ReadLine();
            if (animalType == "Beast!") break;

            try
            {
                AddAnimal(animals, animalType);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        foreach (var animal in animals)
        {
            Console.WriteLine(animal.GetType());
            Console.WriteLine($"{animal.Name} {animal.Age} {animal.Gender}");
            animal.ProduceSound();
        }
    }

    private static void AddAnimal(List<Animal> animals, string animalType)
    {
        string[] animalInfo = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
            .ToArray();
        string name = animalInfo[0];
        int age = int.Parse(animalInfo[1]);
        string gender = string.Empty;
        if (animalInfo.Length == 3) gender = animalInfo[2];
        else throw new InvalidInputException();

        switch (animalType.ToLower())
        {
            case "dog":
                Dog dog = new Dog(name, age, gender);
                animals.Add(dog);
                break;
            case "cat":
                Cat cat = new Cat(name, age, gender);
                animals.Add(cat);
                break;
            case "frog":
                Frog frog = new Frog(name, age, gender);
                animals.Add(frog);
                break;
            case "kitten":
                Kitten kitten = new Kitten(name, age);
                animals.Add(kitten);
                break;
            case "tomcat":
                Tomcat tomcat = new Tomcat(name, age);
                animals.Add(tomcat);
                break;
            default: throw new InvalidInputException();
        }
    }
}
