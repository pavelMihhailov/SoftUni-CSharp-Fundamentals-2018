using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        int lines = int.Parse(Console.ReadLine());
        var userData = new SortedDictionary<string, SortedDictionary<string, int>>();

        for (int i = 0; i < lines; i++)
        {
            string[] input = Console.ReadLine().Split();
            string ip = input[0];
            string user = input[1];
            int duration = int.Parse(input[2]);

            if (!userData.ContainsKey(user)) userData.Add(user, new SortedDictionary<string, int>());
            if (!userData[user].ContainsKey(ip)) userData[user].Add(ip, 0);
            userData[user][ip] += duration;
        }

        foreach (var user in userData)
        {
            int countIp = user.Value.Keys.Count;
            int cnt = 0;
            Console.Write($"{user.Key}: {user.Value.Values.Sum()} [");
            foreach (var ip in user.Value)
            {
                cnt++;
                if (countIp == cnt) Console.WriteLine($"{ip.Key}]");
                else Console.Write($"{ip.Key}, ");
            }
        }
    }
}
