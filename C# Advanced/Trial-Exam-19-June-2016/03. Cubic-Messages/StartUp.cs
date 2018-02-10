using System;
using System.Text;
using System.Text.RegularExpressions;

public class Program
{
    public static void Main()
    {
        while (true)
        {
            string line = Console.ReadLine();
            if (line == "Over!") break;

            int length = int.Parse(Console.ReadLine());

            string pattern = @"^([0-9]+)([A-Za-z]{" + length + @"})([^A-Za-z]*$)";
            Match match = Regex.Match(line, pattern);

            if (match.Success)
            {
                string indexes = match.Groups[1].Value + match.Groups[3].Value;
                string word = match.Groups[2].Value;

                StringBuilder result = new StringBuilder();

                for (int i = 0; i < indexes.Length; i++)
                {
                    if (Char.IsDigit(indexes[i]))
                    {
                        int index = int.Parse(indexes[i].ToString());
                        if (index <= word.Length - 1)
                        {
                            result.Append(word[index]);
                        }
                        else result.Append(' ');
                    }
                }
                Console.WriteLine($"{word} == {result}");
            }
        }
    }
}
