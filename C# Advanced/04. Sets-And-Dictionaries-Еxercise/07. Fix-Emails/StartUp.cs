using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        Dictionary<string, string> data = new Dictionary<string, string>();

        while (true)
        {
            string name = Console.ReadLine();
            if (name == "stop") break;
            string email = Console.ReadLine();
            if (email.EndsWith("uk") || email.EndsWith("us")) continue;
            else
            {
                if (!data.ContainsKey(name)) data.Add(name, null);
                data[name] = email;
            }
        }
        foreach (var person in data)
        {
            Console.WriteLine($"{person.Key} -> {person.Value}");
        }
    }
}
