using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        string[] contactInfo = Console.ReadLine().Split("-".ToCharArray()).ToArray();
        Dictionary<string, string> phoneBook = new Dictionary<string, string>();
        bool searching = false;

        while (true)
        {
            if (contactInfo[0] == "stop") break;
            if (contactInfo[0] == "search") searching = true;
            else if (!searching)
            {
                if (!phoneBook.ContainsKey(contactInfo[0])) phoneBook.Add(contactInfo[0], contactInfo[1]);
                else phoneBook[contactInfo[0]] = contactInfo[1];
            }
            else
            {
                if (phoneBook.ContainsKey(contactInfo[0]))
                {
                    Console.WriteLine($"{contactInfo[0]} -> {phoneBook[contactInfo[0]]}");
                }
                else Console.WriteLine($"Contact {contactInfo[0]} does not exist.");
            }
            contactInfo = Console.ReadLine().Split("-".ToCharArray()).ToArray();
        }
    }
}