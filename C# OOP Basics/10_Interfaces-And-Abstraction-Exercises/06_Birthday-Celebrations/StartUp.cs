using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        List<MemberType> members = new List<MemberType>();

        while (true)
        {
            string[] input = Console.ReadLine().Split();
            if (input[0] == "End") break;

            string memberType = input[0];

            switch (memberType)
            {
                case "Citizen":
                    Citizen citizen = new Citizen(input[1], int.Parse(input[2]), input[3], input[4]);
                    members.Add(citizen);
                    break;
                case "Pet":
                    Pet pet = new Pet(input[1], input[2]);
                    members.Add(pet);
                    break;
            }
        }
        string wantedYear = Console.ReadLine();
        foreach (var member in members)
        {
            if (member.SameYear(wantedYear)) Console.WriteLine(member.Birthdate);
        }
    }
}