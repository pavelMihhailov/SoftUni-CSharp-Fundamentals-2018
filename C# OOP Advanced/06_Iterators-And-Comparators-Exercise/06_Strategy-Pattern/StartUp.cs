using System;
using System.Collections.Generic;

public class StartUp
{
    static void Main()
    {
        IComparer<Person> byName = new ByNameComparator();
        IComparer<Person> byAge = new ByAgeComparator();

        SortedSet<Person> sortedByName = new SortedSet<Person>(byName);
        SortedSet<Person> sortedByAge = new SortedSet<Person>(byAge);

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            var info = Console.ReadLine().Split();

            Person person = new Person(info[0], int.Parse(info[1]));

            sortedByName.Add(person);
            sortedByAge.Add(person);
        }

        Console.WriteLine(string.Join("\n", sortedByName));
        Console.WriteLine(string.Join("\n", sortedByAge));
    }
}
