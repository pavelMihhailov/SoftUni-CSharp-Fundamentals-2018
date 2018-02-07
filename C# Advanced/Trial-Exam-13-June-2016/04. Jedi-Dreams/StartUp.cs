using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

internal class Program
{
    public static void Main()
    {
        var declMethodPattern = @"static\s+.*\s+([a-zA-Z]*[A-Z][a-zA-Z]*)\s*\(";
        var declRegex = new Regex(declMethodPattern);
        var invokeMethodPattern = @"([a-zA-Z]*[A-Z][a-zA-Z]*)\s*\(";
        var invokedRegex = new Regex(invokeMethodPattern);

        var allMethods = new List<PrimeMethod>();

        var lines = int.Parse(Console.ReadLine());
        for (var line = 0; line < lines; line++)
        {
            var codeLine = Console.ReadLine();
            var decMethodMatch = declRegex.Match(codeLine);

            if (declRegex.IsMatch(codeLine))
            {
                var currDecMethodName = decMethodMatch.Groups[1].Value;

                PrimeMethod newPrimeMethod = new PrimeMethod();
                newPrimeMethod.Name = currDecMethodName;
                newPrimeMethod.InvokedMethods = new List<string>();

                allMethods.Add(newPrimeMethod);
            }
            else if (allMethods.Count > 0)
            {
                var invokedMatches = invokedRegex.Matches(codeLine);

                foreach (Match match in invokedMatches)
                {
                    var currInvokedMethodName = match.Groups[1].Value;
                    allMethods[allMethods.Count - 1].InvokedMethods.Add(currInvokedMethodName);
                }
            }
        }

        foreach (var method in allMethods.OrderByDescending(i => i.InvokedMethods.Count).ThenBy(x => x.Name).ToList())
        {
            if (method.InvokedMethods.Count > 0)
            {
                Console.WriteLine(
                    $"{method.Name} -> {method.InvokedMethods.Count} -> {string.Join(", ", method.InvokedMethods.OrderBy(i => i))}");
            }
            else Console.WriteLine("{0} -> None", method.Name);
        }
    }

    private class PrimeMethod
    {
        public string Name { get; set; }
        public List<string> InvokedMethods { get; set; }
    }
}