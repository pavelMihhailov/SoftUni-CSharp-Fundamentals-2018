using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        SortedSet<Person> sortedSet = new SortedSet<Person>();
        HashSet<Person> hashSet = new HashSet<Person>();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            var info = Console.ReadLine().Split();

            Person person = new Person(info[0], int.Parse(info[1]));

            sortedSet.Add(person);
            hashSet.Add(person);
        }

        Console.WriteLine(sortedSet.Count);
        Console.WriteLine(hashSet.Count);
    }
}
