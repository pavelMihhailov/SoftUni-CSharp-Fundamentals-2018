using System;
using System.Collections.Generic;
using System.Linq;

class StartUp
{
    static void Main()
    {
        string[] input = Console.ReadLine().ToLower().Split();

        Dictionary<string, int> mainItemsData = new Dictionary<string, int>()
        {
            {"shards", 0},
            {"fragments", 0},
            {"motes", 0}
        };
        Dictionary<string, int> junkData = new Dictionary<string, int>();
        bool isFound = false;

        while (true)
        {
            for (int i = 0; i < input.Length; i += 2)
            {
                string item = input[i + 1];
                int quantity = int.Parse(input[i]);
                if (item == "shards") mainItemsData["shards"] += quantity;

                else if (item == "fragments") mainItemsData["fragments"] += quantity;

                else if (item == "motes") mainItemsData["motes"] += quantity;

                else
                {
                    if (!junkData.ContainsKey(item)) junkData.Add(item, 0);
                    junkData[item] += quantity;
                }

                if (mainItemsData["shards"] >= 250)
                {
                    Console.WriteLine("Shadowmourne obtained!");
                    mainItemsData["shards"] -= 250;
                    isFound = true;
                    break;
                }
                if (mainItemsData["fragments"] >= 250)
                {
                    Console.WriteLine("Valanyr obtained!");
                    mainItemsData["fragments"] -= 250;
                    isFound = true;
                    break;
                }
                if (mainItemsData["motes"] >= 250)
                {
                    Console.WriteLine("Dragonwrath obtained!");
                    mainItemsData["motes"] -= 250;
                    isFound = true;
                    break;
                }
            }
            if (isFound) break;
            input = Console.ReadLine().ToLower().Split();
        }
        foreach (var item in mainItemsData.OrderByDescending(i => i.Value).ThenBy(i => i.Key))
        {
            Console.WriteLine($"{item.Key}: {item.Value}");
        }
        foreach (var junk in junkData.OrderBy(i => i.Key))
        {
            Console.WriteLine($"{junk.Key}: {junk.Value}");
        }
    }
}
