using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        List<int> gems = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToList();
        Queue<KeyValuePair<string, int>> exclusionFilters = new Queue<KeyValuePair<string, int>>();

        AddFiltersAndExecuteThem(gems, exclusionFilters);

        Console.WriteLine(string.Join(" ", gems));
    }

    private static void AddFiltersAndExecuteThem(List<int> gems, Queue<KeyValuePair<string, int>> exclusionFilters)
    {
        while (true)
        {
            string[] input = Console.ReadLine().Split(';');
            if (input[0] == "Forge") break;

            string command = input[0];
            string filterType = input[1];
            int parameter = int.Parse(input[2]);

            if (command == "Exclude") exclusionFilters.Enqueue(new KeyValuePair<string, int>(filterType, parameter));
            else if (command == "Reverse" && exclusionFilters.Count > 0) exclusionFilters.Dequeue();
        }

        foreach (var filter in exclusionFilters.Reverse())
        {
            switch (filter.Key)
            {
                case "Sum Left":
                    GetLeftSum(gems, filter.Value);
                    break;
                case "Sum Right":
                    GetRightSum(gems, filter.Value);
                    break;
                case "Sum Left Right":
                    GetLeftRightSum(gems, filter.Value);
                    break;
            }
        }
    }

    public static void GetLeftSum(List<int> gems, int wantedSum)
    {
        for (int i = gems.Count - 1; i >= 0; i--)
        {
            int leftGem = i == 0 ? 0 : gems[i - 1];
            if (gems[i] + leftGem == wantedSum) gems.RemoveAt(i);
        }
    }
    public static void GetRightSum(List<int> gems, int wantedSum)
    {
        for (int i = 0; i < gems.Count; i++)
        {
            int rightGem = i == gems.Count - 1 ? 0 : gems[i + 1];
            if (gems[i] + rightGem == wantedSum)
            {
                gems.RemoveAt(i);
                i--;
            }
        }
    }

    public static void GetLeftRightSum(List<int> gems, int wantedSum)
    {
        for (int i = 0; i < gems.Count; i++)
        {
            int leftGem = i == 0 ? 0 : gems[i - 1];
            int rightGem = i == gems.Count - 1 ? 0 : gems[i + 1];
            if (gems[i] + leftGem + rightGem == wantedSum)
            {
                gems.RemoveAt(i);
                i--;
            }
        }
    }
}
