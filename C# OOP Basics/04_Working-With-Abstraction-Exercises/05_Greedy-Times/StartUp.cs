using System;
using System.Collections.Generic;
using System.Linq;

public class Potato
{
    static void Main()
    {
        long bagCapacity = long.Parse(Console.ReadLine());
        string[] sequence = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        var bag = new Dictionary<string, Dictionary<string, long>>();
        long gold = 0;
        long gems = 0;
        long cash = 0;

        for (int i = 0; i < sequence.Length; i += 2)
        {
            string name = sequence[i];
            long amount = long.Parse(sequence[i + 1]);

            string item = string.Empty;

            if (name.Length == 3) item = "Cash";
            else if (name.ToLower().EndsWith("gem")) item = "Gem";
            else if (name.ToLower() == "gold") item = "Gold";

            if (item == "") continue;
            if (bagCapacity < bag.Values.Select(x => x.Values.Sum()).Sum() + amount)
                continue;

            switch (item)
            {
                case "Gem":
                    if (!bag.ContainsKey(item))
                    {
                        if (bag.ContainsKey("Gold"))
                        {
                            if (amount > bag["Gold"].Values.Sum()) continue;
                        }
                        else continue;
                    }
                    else if (bag[item].Values.Sum() + amount > bag["Gold"].Values.Sum())
                    {
                        continue;
                    }
                    break;
                case "Cash":
                    if (!bag.ContainsKey(item))
                    {
                        if (bag.ContainsKey("Gem"))
                        {
                            if (amount > bag["Gem"].Values.Sum()) continue;
                        }
                        else continue;
                    }
                    else if (bag[item].Values.Sum() + amount > bag["Gem"].Values.Sum())
                        continue;
                    break;
            }

            if (!bag.ContainsKey(item))
            {
                bag[item] = new Dictionary<string, long>();
            }

            if (!bag[item].ContainsKey(name))
            {
                bag[item][name] = 0;
            }
            AddItemInTheBag(bag, ref gold, ref gems, ref cash, name, amount, item);
        }
        Print(bag);
    }

    private static void AddItemInTheBag(Dictionary<string, Dictionary<string, long>> bag, ref long gold, ref long gems, ref long cash, string name, long amount, string item)
    {
        bag[item][name] += amount;
        if (item == "Gold")
        {
            gold += amount;
        }
        else if (item == "Gem")
        {
            gems += amount;
        }
        else if (item == "Cash")
        {
            cash += amount;
        }
    }

    private static void Print(Dictionary<string, Dictionary<string, long>> bag)
    {
        foreach (var item in bag)
        {
            Console.WriteLine($"<{item.Key}> ${item.Value.Values.Sum()}");
            foreach (var subItem in item.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
            {
                Console.WriteLine($"##{subItem.Key} - {subItem.Value}");
            }
        }
    }
}