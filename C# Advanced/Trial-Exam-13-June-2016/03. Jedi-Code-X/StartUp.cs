using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        StringBuilder text = new StringBuilder();
        Queue<string> names = new Queue<string>();
        List<string> messages = new List<string>();

        for (int i = 0; i < n; i++)
        {
            text.Append(Console.ReadLine());
        }
        string firstPattern = Console.ReadLine();
        string secondPattern = Console.ReadLine();
        int[] messageIndexes = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToArray();

        string namePattern = firstPattern + @"([A-Za-z]{" + Regex.Escape(firstPattern.Length.ToString()) + @"})(?![a-zA-Z])";
        string messagePattern =
            secondPattern + @"([A-Za-z0-9]{" + Regex.Escape(secondPattern.Length.ToString()) + @"})(?![a-zA-Z0-9])";

        ExtractNamesAndMsgs(text, names, messages, namePattern, messagePattern);

        foreach (var index in messageIndexes)
        {
            if (index - 1 < messages.Count && index > 0 && names.Count > 0)
            {
                string jediName = names.Dequeue();
                string jediMessage = messages[index - 1];
                Console.WriteLine($"{jediName} - {jediMessage}");
            }
        }
    }

    private static void ExtractNamesAndMsgs(StringBuilder text, Queue<string> names, List<string> messages, string namePattern, string messagePattern)
    {
        //extract names
        MatchCollection nameMatches = Regex.Matches(text.ToString(), namePattern);
        foreach (Match name in nameMatches)
        {
            names.Enqueue(name.Groups[1].Value);
        }

        //extractMessages
        MatchCollection messageMatches = Regex.Matches(text.ToString(), messagePattern);
        foreach (Match message in messageMatches)
        {
            messages.Add(message.Groups[1].Value);
        }
    }
}
