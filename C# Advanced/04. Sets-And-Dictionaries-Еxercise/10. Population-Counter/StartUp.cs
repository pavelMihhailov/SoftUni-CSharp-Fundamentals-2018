using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        string[] input = Console.ReadLine().Split('|');
        var countryData = new Dictionary<string, Dictionary<string, long>>();

        while (input[0] != "report")
        {
            string city = input[0];
            string country = input[1];
            long populationInCity = long.Parse(input[2]);

            if (!countryData.ContainsKey(country)) countryData.Add(country, new Dictionary<string, long>());
            if (!countryData[country].ContainsKey(city)) countryData[country].Add(city, populationInCity);

            input = Console.ReadLine().Split('|');
        }

        foreach (var country in countryData.OrderByDescending(c => c.Value.Values.Sum()))
        {
            Console.WriteLine($"{country.Key} (total population: {country.Value.Values.Sum()})");
            foreach (var city in country.Value.OrderByDescending(c => c.Value))
            {
                Console.WriteLine($"=>{city.Key}: {city.Value}");
            }
        }
    }
}
