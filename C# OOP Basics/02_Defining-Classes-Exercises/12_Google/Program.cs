using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        List<Person> peopleList = new List<Person>();

        while (true)
        {
            string[] line = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            if (line[0] == "End") break;

            string personName = line[0];
            Person newPerson = new Person();

            //check if that person exists
            int indexOfPerson = -2;
            for (int i = 0; i < peopleList.Count; i++)
            {
                if (peopleList[i].Name.Equals(personName))
                {
                    indexOfPerson = i;
                    break;
                }
            }

            AddInfo(peopleList, line, newPerson, indexOfPerson);

            //if not exist add to list
            if (indexOfPerson == -2)
            {
                newPerson.Name = personName;
                peopleList.Add(newPerson);
            }
        }
        string nameToPrint = Console.ReadLine();

        Print(peopleList, nameToPrint);
    }

    private static void AddInfo(List<Person> peopleList, string[] line, Person newPerson, int indexOfPerson)
    {
        switch (line[1])
        {
            case "company":
                Company newCompany = new Company(line[2], line[3], decimal.Parse(line[4]));
                if (indexOfPerson == -2)
                {
                    newPerson.Company = newCompany;
                }
                else peopleList[indexOfPerson].Company = newCompany;
                break;
            case "pokemon":
                Pokemon newPokemon = new Pokemon(line[2], line[3]);
                if (indexOfPerson == -2) newPerson.Pokemons = new List<Pokemon> { newPokemon };
                else peopleList[indexOfPerson].Pokemons.Add(newPokemon);
                break;
            case "parents":
                Parent newParent = new Parent(line[2], line[3]);
                if (indexOfPerson == -2) newPerson.Parents = new List<Parent> { newParent };
                else peopleList[indexOfPerson].Parents.Add(newParent);
                break;
            case "children":
                Children newChildren = new Children(line[2], line[3]);
                if (indexOfPerson == -2) newPerson.Childrens = new List<Children> { newChildren };
                else peopleList[indexOfPerson].Childrens.Add(newChildren);
                break;
            case "car":
                Car newCar = new Car(line[2], int.Parse(line[3]));
                if (indexOfPerson == -2)
                {
                    newPerson.Car = newCar;
                    newPerson.Company = null;
                }
                else peopleList[indexOfPerson].Car = newCar;
                break;
        }
    }

    private static void Print(List<Person> peopleList, string nameToPrint)
    {
        int index = peopleList.FindIndex(x => x.Name.Equals(nameToPrint));

        Console.WriteLine(nameToPrint);
        Console.WriteLine($"Company:");
        if (peopleList[index].Company != null)
        {
            Console.WriteLine($"{peopleList[index].Company.Name} {peopleList[index].Company.Department} {peopleList[index].Company.Salary:f2}");
        }
        Console.WriteLine("Car:");
        if (peopleList[index].Car != null)
        {
            Console.WriteLine($"{peopleList[index].Car.Model} {peopleList[index].Car.Speed}");
        }
        Console.WriteLine("Pokemon:");
        foreach (var pokemon in peopleList[index].Pokemons)
        {
            Console.WriteLine($"{pokemon.Name} {pokemon.Type}");
        }
        Console.WriteLine("Parents:");
        foreach (var parent in peopleList[index].Parents)
        {
            Console.WriteLine($"{parent.Name} {parent.Birthday}");
        }
        Console.WriteLine("Children:");
        foreach (var child in peopleList[index].Childrens)
        {
            Console.WriteLine($"{child.Name} {child.Birthday}");
        }
    }
}
