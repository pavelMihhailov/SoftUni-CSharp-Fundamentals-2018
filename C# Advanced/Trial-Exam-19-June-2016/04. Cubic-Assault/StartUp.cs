using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    public const int FillCnt = 1_000_000;

    static void Main()
    {
        Dictionary<string, Dictionary<string, long>> regionInfo = new Dictionary<string, Dictionary<string, long>>();

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "Count em all") break;

            string[] tokens = input.Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            string region = tokens[0];
            string typeRegion = tokens[1];
            long value = long.Parse(tokens[2]);

            AddInfoAboutRegion(regionInfo, region, typeRegion, value);
            ChangeValueIfNeeded(regionInfo, region);
        }
        Print(regionInfo);
    }

    private static void ChangeValueIfNeeded(Dictionary<string, Dictionary<string, long>> regionInfo, string region)
    {
        while (regionInfo[region]["Green"] >= FillCnt)
        {
            regionInfo[region]["Green"] -= FillCnt;
            regionInfo[region]["Red"]++;
        }
        while (regionInfo[region]["Red"] >= FillCnt)
        {
            regionInfo[region]["Red"] -= FillCnt;
            regionInfo[region]["Black"]++;
        }
    }

    private static void Print(Dictionary<string, Dictionary<string, long>> regionInfo)
    {
        foreach (var regionName in regionInfo.OrderByDescending(x => x.Value["Black"]).ThenBy(x => x.Key.Length).ThenBy(x => x.Key))
        {
            Console.WriteLine(regionName.Key);
            foreach (var meteors in regionName.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"-> {meteors.Key} : {meteors.Value}");
            }
        }
    }

    private static void AddInfoAboutRegion(Dictionary<string, Dictionary<string, long>> regionInfo, string region, string typeRegion, long value)
    {
        if (!regionInfo.ContainsKey(region))
        {
            regionInfo.Add(region, new Dictionary<string, long>());
            regionInfo[region].Add("Red", 0);
            regionInfo[region].Add("Black", 0);
            regionInfo[region].Add("Green", 0);
        }
        switch (typeRegion)
        {
            case "Red":
                regionInfo[region]["Red"] += value;
                break;
            case "Black":
                regionInfo[region]["Black"] += value;
                break;
            case "Green":
                regionInfo[region]["Green"] += value;
                break;
        }
    }
}
