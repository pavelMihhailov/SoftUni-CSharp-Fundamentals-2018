using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class StartUp
{
    public static void Main()
    {
        string input = Console.ReadLine();
        var concertInfo = new Dictionary<string, Dictionary<string, long>>();

        while (input != "End")
        {
            string pattern = @"([A-Za-z ]+) @([A-Za-z ]+) (\d+) (\d+)";

            Match match = Regex.Match(input, pattern);

            if (match.Success)
            {
                string singer = match.Groups[1].ToString().Trim(' ', '@');
                string city = match.Groups[2].ToString().Trim(' ', '@');
                long ticketsCount = long.Parse(match.Groups[3].Value);
                long ticketsPrice = long.Parse(match.Groups[4].Value);

                if (!concertInfo.ContainsKey(city)) concertInfo.Add(city, new Dictionary<string, long>());
                if (concertInfo[city].ContainsKey(singer)) concertInfo[city][singer] += ticketsPrice * ticketsCount;
                else concertInfo[city].Add(singer, ticketsPrice * ticketsCount);
            }
            input = Console.ReadLine();
        }
        foreach (var city in concertInfo)
        {
            Console.WriteLine($"{city.Key}");
            foreach (var singer in city.Value.OrderByDescending(i => i.Value))
            {
                Console.WriteLine($"#  {singer.Key} -> {singer.Value}");
            }
        }
    }
}
