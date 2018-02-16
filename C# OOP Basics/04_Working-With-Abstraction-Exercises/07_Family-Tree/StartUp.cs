using System;
using System.Collections.Generic;
using System.Linq;

class StartUp
{
    static void Main()
    {
        var familyTree = new List<Person>();
        string personInput = Console.ReadLine();
        Person wantedPerson = new Person();

        if (IsBirthday(personInput))
        {
            wantedPerson.Birthday = personInput;
        }
        else wantedPerson.Name = personInput;

        familyTree.Add(wantedPerson);

        string command;
        while ((command = Console.ReadLine()) != "End")
        {
            string[] tokens = command.Split(" - ");
            if (tokens.Length > 1)
            {
                string firstPerson = tokens[0];
                string secondPerson = tokens[1];

                Person currentPerson;

                if (IsBirthday(firstPerson))
                {
                    currentPerson = familyTree.FirstOrDefault(p => p.Birthday == firstPerson);

                    if (currentPerson == null)
                    {
                        currentPerson = new Person();
                        currentPerson.Birthday = firstPerson;
                        familyTree.Add(currentPerson);
                    }

                    SetChild(familyTree, currentPerson, secondPerson);
                }
                else
                {
                    currentPerson = familyTree.FirstOrDefault(p => p.Name == firstPerson);

                    if (currentPerson == null)
                    {
                        currentPerson = new Person();
                        currentPerson.Name = firstPerson;
                        familyTree.Add(currentPerson);
                    }

                    SetChild(familyTree, currentPerson, secondPerson);
                }
            }
            else
            {
                tokens = tokens[0].Split();
                string name = $"{tokens[0]} {tokens[1]}";
                string birthday = tokens[2];

                var person = familyTree.FirstOrDefault(p => p.Name == name || p.Birthday == birthday);
                if (person == null)
                {
                    person = new Person();
                    familyTree.Add(person);
                }
                person.Name = name;
                person.Birthday = birthday;

                int index = familyTree.IndexOf(person) + 1;
                int count = familyTree.Count - index;

                Person[] copy = new Person[count];
                familyTree.CopyTo(index, copy, 0, count);

                Person copyPerson = copy.FirstOrDefault(p => p.Name == name || p.Birthday == birthday);

                if (copyPerson != null)
                {
                    familyTree.Remove(copyPerson);
                    person.Parents.AddRange(copyPerson.Parents);
                    person.Parents = person.Parents.Distinct().ToList();

                    foreach (var parent in copyPerson.Parents)
                    {
                        int copyPersonIndex = parent.Children.IndexOf(copyPerson);
                        if (copyPersonIndex > -1)
                        {
                            parent.Children[copyPersonIndex] = person;
                        }
                        else
                        {
                            parent.Children.Add(person);
                        }
                    }

                    person.Children.AddRange(copyPerson.Children);
                    person.Children = person.Children.Distinct().ToList();
                }
            }
        }

        Print(wantedPerson);
    }

    private static void Print(Person wantedPerson)
    {
        Console.WriteLine(wantedPerson);
        Console.WriteLine("Parents:");
        foreach (var parent in wantedPerson.Parents)
        {
            Console.WriteLine(parent);
        }
        Console.WriteLine("Children:");
        foreach (var child in wantedPerson.Children)
        {
            Console.WriteLine(child);
        }
    }

    private static void SetChild(List<Person> familyTree, Person parentPerson, string birthday)
    {
        var child = new Person();

        if (IsBirthday(birthday))
        {
            if (familyTree.All(p => p.Birthday != birthday))
            {
                child.Birthday = birthday;
            }
            else
            {
                child = familyTree.First(p => p.Birthday == birthday);
            }
        }
        else
        {
            if (familyTree.All(p => p.Name != birthday))
            {
                child.Name = birthday;
            }
            else
            {
                child = familyTree.First(p => p.Name == birthday);
            }
        }

        parentPerson.Children.Add(child);
        child.Parents.Add(parentPerson);
        familyTree.Add(child);
    }

    static bool IsBirthday(string input)
    {
        return Char.IsDigit(input[0]);
    }
}
