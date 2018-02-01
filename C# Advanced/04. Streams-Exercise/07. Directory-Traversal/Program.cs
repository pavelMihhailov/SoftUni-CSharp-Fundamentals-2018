using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _07._Directory_Traversal
{
    class Program
    {
        public static void Main()
        {
            Console.Write("Type in a directory to be traversed: ");
            var directory = Console.ReadLine();

            var filesColletion = new Dictionary<string, Dictionary<string, double>>();
            var allFilenames = new List<string>(Directory.GetFiles("../../test files"));

            foreach (var filePath in allFilenames)
            {
                var extension = filePath.Split('.').Last();
                if (!filesColletion.ContainsKey(extension))
                {
                    filesColletion[extension] = new Dictionary<string, double>();
                }
                double fileSize = 0;
                using (var sourceStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    fileSize = sourceStream.Length / 1024.00;

                var filename = Path.GetFileName(filePath);
                filesColletion[extension].Add(filename, fileSize);
            }

            SortAndExtractFilesInfo(filesColletion);
        }

        private static void SortAndExtractFilesInfo(Dictionary<string, Dictionary<string, double>> filesColletion)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\report.txt";

            using (var destination = new StreamWriter(desktopPath))
                foreach (var extension in filesColletion.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
                {
                    destination.WriteLine($".{extension.Key}");
                    destination.WriteLine(string.Join(Environment.NewLine.ToString(),
                        extension.Value.OrderBy(x => x.Value).Select(x => $"--{x.Key} = {x.Value:f3}kb")));
                }
        }
    }
}
