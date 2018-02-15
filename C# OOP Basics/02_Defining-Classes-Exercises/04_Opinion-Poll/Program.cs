using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    public static List<Person> listOfPeople = new List<Person>();
    static void Main()
    {
        AddPeople();
        foreach (var person in listOfPeople.Where(x => x.Age > 30).OrderBy(x => x.Name))
        {
            Console.WriteLine($"{person.Name} - {person.Age}");
        }
    }

    private static void AddPeople()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split();
            string name = input[0];
            int age = int.Parse(input[1]);

            Person newPerson = new Person(name, age);
            listOfPeople.Add(newPerson);
        }
    }
}
