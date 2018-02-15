using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Family family = new Family();

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split();
            string name = input[0];
            int age = int.Parse(input[1]);

            Person newPerson = new Person(name, age);
            family.AddMembers(newPerson);
        }
        Console.WriteLine($"{family.GetOldestMember().Name} {family.GetOldestMember().Age}");
    }
}