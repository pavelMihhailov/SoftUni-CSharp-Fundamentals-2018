using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class StartUp
{
    public static void Main()
    {
        string input = Console.ReadLine();
        string ipPattern = @"IP=(([a-z]*[A-Z]*[0-9]*\:*\.*)+)";
        string userPattern = @"user=(\w+)";

        var userData = new SortedDictionary<string, Dictionary<string, int>>();

        while (input != "end")
        {
            Match ipMatch = Regex.Match(input, ipPattern);
            Match userMatch = Regex.Match(input, userPattern);
            string ip = ipMatch.Groups[1].Value;
            string user = userMatch.Groups[1].Value;

            if (!userData.ContainsKey(user)) userData.Add(user, new Dictionary<string, int>());
            if (userData[user].ContainsKey(ip)) userData[user][ip]++;
            else userData[user].Add(ip, 1);

            input = Console.ReadLine();
        }
        Print(userData);
    }

    private static void Print(SortedDictionary<string, Dictionary<string, int>> userData)
    {
        foreach (var user in userData)
        {
            int countIp = user.Value.Values.Count;
            int cnt = 0;
            Console.WriteLine($"{user.Key}: ");
            foreach (var value in user.Value)
            {
                cnt++;
                if (cnt == countIp) Console.WriteLine($"{value.Key} => {value.Value}.");
                else Console.Write($"{value.Key} => {value.Value}, ");
            }
        }
    }
}
