using System;
using System.Text.RegularExpressions;

public class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        string pattern = @"(?<=!|#)[^!#]*?([a-zA-Z]{4})[^!#]+(?<!\d)(\d{3})-(\d{4}|\d{6})(?!\d)[^!#]*(?=!|#)";

        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();
            if (Regex.IsMatch(input, pattern))
            {
                MatchCollection matches = Regex.Matches(input, pattern);
                var correctMatch = matches[matches.Count / 2];

                string streetName = correctMatch.Groups[1].Value;
                string streetNumber = correctMatch.Groups[2].Value;
                string pass = correctMatch.Groups[3].Value;

                Console.WriteLine($"Go to str. {streetName} {streetNumber}. Secret pass: {pass}.");
            }
        }
    }
}
