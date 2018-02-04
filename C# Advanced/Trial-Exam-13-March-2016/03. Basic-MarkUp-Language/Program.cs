using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _03._Basic_MarkUp_Language
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            string inversePattern = @"\s*<\s*(inverse)\s*content[\s]*=\s*""([\s]*\w+[\s]*)""[\s]*\/[\s]*>";
            string reversePattern = @"\s*<\s*(reverse)\s*content[\s]*=\s*""([\s]*\w+[\s]*)""[\s]*\/[\s]*>";
            string repeatPattern = @"<[\s]*repeat[\s]+value[\s]*=[\s]*""(\d+)""[\s]*content[\s]*=[\s]*""(\w+)""\/[\s]*>";
            int lineCnt = 1;

            while (true)
            {
                if (command == "<stop/>") break;

                if (Regex.IsMatch(command, inversePattern))
                {
                    StringBuilder result = new StringBuilder();
                    Match match = Regex.Match(command, inversePattern);

                    string wordToEdit = match.Groups[2].Value;

                    for (int i = 0; i < wordToEdit.Length; i++)
                    {
                        char letter = wordToEdit[i];
                        if (Char.IsLower(letter)) result.Append(letter.ToString().ToUpper());
                        else result.Append(letter.ToString().ToLower());
                    }
                    Console.WriteLine($"{lineCnt}. {result}");
                    lineCnt++;
                }
                else if (Regex.IsMatch(command, reversePattern))
                {
                    StringBuilder result = new StringBuilder();
                    Match match = Regex.Match(command, reversePattern);

                    string wordToEdit = match.Groups[2].Value;

                    if (wordToEdit.Length > 0)
                    {
                        for (int i = wordToEdit.Length - 1; i >= 0; i--)
                        {
                            result.Append(wordToEdit[i]);
                        }
                    }
                    Console.WriteLine($"{lineCnt}. {result}");
                    lineCnt++;
                }
                else if (Regex.IsMatch(command, repeatPattern))
                {
                    Match match = Regex.Match(command, repeatPattern);
                    int repeatCnt = int.Parse(match.Groups[1].Value);
                    string forRepeat = match.Groups[2].Value;

                    if (!String.IsNullOrEmpty(forRepeat))
                    { 
                        for (int i = 0; i < repeatCnt; i++)
                        {
                            Console.WriteLine($"{lineCnt}. {forRepeat}");
                            lineCnt++;
                        }
                    }
                }

                command = Console.ReadLine();
            }

        }
    }
}
