using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        using (var readText = new StreamReader("text.txt"))
        {
            using (var readWords = new StreamReader("words.txt"))
            {
                string[] words = new string[3];
                words[0] = readWords.ReadLine();
                words[1] = readWords.ReadLine();
                words[2] = readWords.ReadLine();

                using (var writeResult = new StreamWriter("result.txt"))
                {
                    Dictionary<string, int> wordCount = new Dictionary<string, int>();

                    for (int j = 0; j < 3; j++)
                    {
                        string[] textLine = readText.ReadLine().ToLower().Split();

                        for (int i = 0; i < textLine.Length; i++)
                        {
                            if (words[0] == textLine[i].Trim('.', '-', ','))
                            {
                                if (!wordCount.ContainsKey(words[0])) wordCount.Add(words[0], 0);
                                wordCount[words[0]]++;
                            }
                            else if (words[1] == textLine[i].Trim('.', '-', ','))
                            {
                                if (!wordCount.ContainsKey(words[1])) wordCount.Add(words[1], 0);
                                wordCount[words[1]]++;
                            }
                            else if (words[2] == textLine[i].Trim('.', '-', ','))
                            {
                                if (!wordCount.ContainsKey(words[2])) wordCount.Add(words[2], 0);
                                wordCount[words[2]]++;
                            }
                        }
                    }
                    foreach (var word in wordCount.OrderByDescending(x => x.Value))
                    {
                        writeResult.WriteLine($"{word.Key} - {word.Value}");
                    }
                }
            }
        }
    }
}
