using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        int dragons = int.Parse(Console.ReadLine());

        var dragonData = new Dictionary<string, Dictionary<string, List<int>>>();

        for (int i = 0; i < dragons; i++)
        {
            string[] tokens = Console.ReadLine().Split();
            string type = tokens[0];
            string name = tokens[1];
            string damage = tokens[2];
            string health = tokens[3];
            string armor = tokens[4];

            if (!dragonData.ContainsKey(type)) dragonData.Add(type, new Dictionary<string, List<int>>());
            if (!dragonData[type].ContainsKey(name)) dragonData[type].Add(name, new List<int>(3));

            AddStats(dragonData, type, name, damage, health, armor);
        }
        Print(dragonData);
    }

    private static void Print(Dictionary<string, Dictionary<string, List<int>>> dragonData)
    {
        foreach (var dragon in dragonData)
        {
            Console.WriteLine($"{dragon.Key}::({GetAvgStatsOfDragonType(dragon.Value)})");
            foreach (var statsDragon in dragon.Value.OrderBy(i => i.Key))
            {
                Console.WriteLine($"-{statsDragon.Key} -> damage: {statsDragon.Value[0]}, health: {statsDragon.Value[1]}, armor: {statsDragon.Value[2]}");
            }
        }
    }

    private static string GetAvgStatsOfDragonType(Dictionary<string, List<int>> dragon)
    {
        var damageAvg = new List<int>();
        var healthAvg = new List<int>();
        var armorAvg = new List<int>();

        foreach (var dragonName in dragon)
        {
            damageAvg.Add(dragonName.Value[0]);
            healthAvg.Add(dragonName.Value[1]);
            armorAvg.Add(dragonName.Value[2]);
        }
        return $"{damageAvg.Average():f2}/{healthAvg.Average():f2}/{armorAvg.Average():f2}";
    }

    private static void AddStats(Dictionary<string, Dictionary<string, List<int>>> dragonData, string type, string name, string damage, string health, string armor)
    {
        dragonData[type][name].Clear();
        if (damage == "null") dragonData[type][name].Add(45);
        else dragonData[type][name].Add(int.Parse(damage));

        if (health == "null") dragonData[type][name].Add(250);
        else dragonData[type][name].Add(int.Parse(health));

        if (armor == "null") dragonData[type][name].Add(10);
        else dragonData[type][name].Add(int.Parse(armor));
    }
}
