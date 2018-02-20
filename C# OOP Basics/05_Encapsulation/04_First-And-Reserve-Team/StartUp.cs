﻿using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        var lines = int.Parse(Console.ReadLine());
        var persons = new List<Person>();
        for (int i = 0; i < lines; i++)
        {
            var cmdArgs = Console.ReadLine().Split();
            var person = new Person(cmdArgs[0],
                cmdArgs[1],
                int.Parse(cmdArgs[2]),
                decimal.Parse(cmdArgs[3]));

            persons.Add(person);
        }
        Team newTeam = new Team("SoftUni");
        foreach (var person in persons)
        {
            newTeam.AddPlayer(person);
        }
        Console.WriteLine(newTeam.ToString());
    }
}