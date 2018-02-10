using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        Dictionary<string, Dictionary<string, long>> bagItems = new Dictionary<string, Dictionary<string, long>>();
        bagItems.Add("Gold", new Dictionary<string, long>());
        bagItems.Add("Gem", new Dictionary<string, long>());
        bagItems.Add("Cash", new Dictionary<string, long>());

        long bagCapacity = long.Parse(Console.ReadLine());
        string[] sequence = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        for (int i = 0; i < sequence.Length; i += 2)
        {
            string item = sequence[i].ToLower();
            long value = long.Parse(sequence[i + 1]);

            bagCapacity = AddItemsInTheBag(bagItems, bagCapacity, sequence, i, item, value);
        }

        foreach (var item in bagItems.Where(i => i.Value.Keys.Count > 0).OrderByDescending(x => x.Value.Values.Sum()))
        {
            Console.WriteLine($"<{item.Key}> ${item.Value.Values.Sum()}");
            foreach (var treasure in item.Value.OrderByDescending(x => x.Key).ThenBy(x => x.Value))
            {
                Console.WriteLine($"##{treasure.Key} - {treasure.Value}");
            }
        }
    }

    private static long AddItemsInTheBag(Dictionary<string, Dictionary<string, long>> bagItems, long bagCapacity, string[] sequence, int i, string item, long value)
    {
        if (item.Length == 3)
        {
            if (bagItems["Cash"].Values.Sum() + value <= bagItems["Gem"].Values.Sum() && bagCapacity >= value)
            {
                if (!bagItems["Cash"].ContainsKey(sequence[i])) bagItems["Cash"].Add(sequence[i], 0);
                bagItems["Cash"][sequence[i]] += value;
                bagCapacity -= value;
            }
        }
        else if (item.Length >= 4 && item.EndsWith("gem"))
        {
            if (bagItems["Gem"].Values.Sum() + value <= bagItems["Gold"].Values.Sum() && bagCapacity >= value)
            {
                if (!bagItems["Gem"].ContainsKey(sequence[i])) bagItems["Gem"].Add(sequence[i], 0);
                bagItems["Gem"][sequence[i]] += value;
                bagCapacity -= value;
            }
        }
        else if (item == "gold")
        {
            if (bagCapacity >= value)
            {
                if (!bagItems["Gold"].ContainsKey("Gold")) bagItems["Gold"].Add("Gold", 0);
                bagItems["Gold"]["Gold"] += value;
                bagCapacity -= value;
            }
        }
        return bagCapacity;
    }
}
