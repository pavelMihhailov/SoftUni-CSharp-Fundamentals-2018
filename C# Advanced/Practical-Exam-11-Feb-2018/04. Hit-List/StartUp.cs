using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        int targetInfoIndex = int.Parse(Console.ReadLine());

        Dictionary<string, Dictionary<string, string>> infoDict = new Dictionary<string, Dictionary<string, string>>();

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "end transmissions") break;

            string[] tokens = input.Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();

            if (tokens.Length == 1)
            {
                string[] newTokens = tokens[0].Split("=:".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                string name = newTokens[0];
                string key = newTokens[1];
                string value = newTokens[2];

                if (!infoDict.ContainsKey(name)) infoDict.Add(name, new Dictionary<string, string>());
                if (!infoDict[name].ContainsKey(key)) infoDict[name].Add(key, null);
                infoDict[name][key] = value;
            }
            else
            {
                string[] newTokens = input.Split("=:;".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string name = newTokens[0];
                for (int i = 1; i < newTokens.Length; i += 2)
                {
                    string key = newTokens[i];
                    string value = newTokens[i + 1];

                    if (!infoDict.ContainsKey(name)) infoDict.Add(name, new Dictionary<string, string>());
                    if (!infoDict[name].ContainsKey(key)) infoDict[name].Add(key, null);
                    infoDict[name][key] = value;
                }
            }
        }
        string toKill = Console.ReadLine().Split()[1];
        int infoIndex = 0;

        Console.WriteLine($"Info on {toKill}:");
        foreach (var person in infoDict[toKill].OrderBy(x => x.Key))
        {
            infoIndex += person.Key.Length + person.Value.Length;
            Console.WriteLine($"---{person.Key}: {person.Value}");
        }

        Console.WriteLine($"Info index: {infoIndex}");
        if (infoIndex >= targetInfoIndex) Console.WriteLine("Proceed");
        else Console.WriteLine($"Need {targetInfoIndex - infoIndex} more info.");
    }
}
