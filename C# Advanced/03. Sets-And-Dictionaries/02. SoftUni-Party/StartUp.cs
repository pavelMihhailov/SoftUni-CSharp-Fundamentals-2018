using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var input = Console.ReadLine();

        var vipGuests = new SortedSet<string>();
        var regularGuests = new SortedSet<string>();
        var allGuests = new SortedSet<string>();
        var isParty = false;

        while (input != "END")
        {
            allGuests.Add(input);
            if (input == "PARTY") isParty = true;

            if (char.IsDigit(input.First()) && isParty)
            {
                vipGuests.Add(input);
                allGuests.Remove(input);
            }
            else if (char.IsLetter(input.First()) && isParty)
            {
                regularGuests.Add(input);
                allGuests.Remove(input);
            }
            input = Console.ReadLine();
        }
        if (allGuests.Count > 0)
        {
            Console.WriteLine(allGuests.Count);
            foreach (var guest in allGuests)
                Console.WriteLine(guest);
        }
        else
        {
            Console.WriteLine("0");
        }
    }
}