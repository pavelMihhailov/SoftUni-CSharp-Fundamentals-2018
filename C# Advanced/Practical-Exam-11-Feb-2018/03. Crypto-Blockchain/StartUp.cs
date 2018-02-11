using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

public class StartUp
{
    public static void Main()
    {
        StringBuilder text = new StringBuilder();
        int n = int.Parse(Console.ReadLine());

        string pattern = @"(\[|\{)([^0-9\[\{]*([0-9]{3,})[^0-9\]\}]*)(\]|\})";

        for (int i = 0; i < n; i++)
        {
            text.Append(Console.ReadLine());
        }

        MatchCollection matches = Regex.Matches(text.ToString(), pattern);

        StringBuilder result = new StringBuilder();

        foreach (Match match in matches)
        {
            if (match.ToString().StartsWith("[") && match.ToString().EndsWith("]") ||
                match.ToString().StartsWith("{") && match.ToString().EndsWith("}"))
            {
                int lengthOfBlock = match.Groups[2].Length + 2;
                string numbers = match.Groups[3].Value;
                if (numbers.Length % 3 != 0) break;

                List<int> listOfNums = new List<int>();

                for (int i = 0; i < numbers.Length; i += 3)
                {
                    listOfNums.Add(int.Parse(numbers.Substring(i, 3)));
                }
                for (int i = 0; i < listOfNums.Count; i++)
                {
                    int asciiCode = listOfNums[i] - lengthOfBlock;
                    if (asciiCode >= 32)
                    {
                        result.Append((char)asciiCode);
                    }
                }
            }
        }
        Console.WriteLine(result);
    }
}
