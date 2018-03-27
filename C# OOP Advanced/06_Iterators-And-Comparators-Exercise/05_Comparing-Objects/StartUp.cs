using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        List<Person> collection = new List<Person>();
        ReadAndAddPeople(collection);

        var indexOfPerson = int.Parse(Console.ReadLine());

        int equalPeople = 1;
        int notEqualPeople = 0;

        Compare2Persons(collection, indexOfPerson, ref equalPeople, ref notEqualPeople);
        if (equalPeople == 1) Console.WriteLine("No matches");
        else Console.WriteLine($"{equalPeople} {notEqualPeople} {collection.Count + 1}");
    }

    private static void Compare2Persons(List<Person> collection, int indexOfPerson, ref int equalPeople, ref int notEqualPeople)
    {
        var personToCompare = collection[indexOfPerson - 1];
        collection.RemoveAt(indexOfPerson - 1);
        foreach (var person in collection)
        {
            if (personToCompare.CompareTo(person) == 0) equalPeople++;
            else notEqualPeople++;
        }
    }

    private static void ReadAndAddPeople(List<Person> collection)
    {
        while (true)
        {
            var command = Console.ReadLine().Split();
            if (command[0].Equals("END")) break;

            string name = command[0];
            int age = int.Parse(command[1]);
            string town = command[2];

            Person person = new Person(name, age, town);
            collection.Add(person);
        }
    }
}
