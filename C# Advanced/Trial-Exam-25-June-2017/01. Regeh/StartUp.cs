using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

public class StartUp
{
    public static void Main()
    {
        string input = Console.ReadLine();
        string pattern = @"\[[^\s\[]+<([0-9]+)REGEH([0-9]+)>[^\s\]]+\]";
        MatchCollection matches = Regex.Matches(input, pattern);

        StringBuilder resultString = new StringBuilder();
        List<int> indexes = new List<int>();

        //extract indexes
        foreach (Match match in matches)
        {
            indexes.Add(int.Parse(match.Groups[1].Value));
            indexes.Add(int.Parse(match.Groups[2].Value));
        }
        //sum indexes
        for (int i = 0; i < indexes.Count; i++)
        {
            int index = 0;
            for (int j = 0; j <= i; j++)
            {
                index += indexes[j];
            }
            resultString.Append(input[index % (input.Length - 1)]);
        }
        Console.WriteLine(resultString);
    }
}
