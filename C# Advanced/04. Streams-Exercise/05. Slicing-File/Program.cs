using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _05.Slicing_File
{
    public class SlicingFile
    {
        public static void Main()
        {
            Console.Write("Choose to how many parts to slice the file: ");
            var parts = int.Parse(Console.ReadLine());
            var directory = "../../sliced files/";

            Slice("video.flv", directory, parts);
            var slicedFiles = new List<string>(Directory.GetFiles(directory));
            Assemble(slicedFiles, "../../");
        }

        public static void Slice(string sourceFile, string destinationDirectory, int parts)
        {
            var extension = sourceFile.Split('.').Last();
            Directory.CreateDirectory(destinationDirectory);
            using (var source = new FileStream(sourceFile, FileMode.Open))
            {
                var buffer = new byte[source.Length / parts + source.Length % parts];
                int count = 1;
                int readBytes = source.Read(buffer, 0, buffer.Length);

                while (readBytes > 0)
                {
                    var destinationFilePath = $"{destinationDirectory}/Part -{count.ToString()}.{extension}";
                    using (var destination = new FileStream(destinationFilePath, FileMode.Create))
                    {
                        destination.Write(buffer, 0, buffer.Length);
                    }
                    readBytes = source.Read(buffer, 0, buffer.Length);
                    count++;
                }
            }
        }

        public static void Assemble(List<string> files, string destinationDirectory)
        {
            Directory.CreateDirectory(destinationDirectory);
            var destinationFilename = $"{destinationDirectory}assembled.flv";

            using (var destination = new FileStream(destinationFilename, FileMode.Create))
            {
                foreach (var filename in files)
                {
                    using (var source = new FileStream(filename, FileMode.Open))
                    {
                        var buffer = new byte[4096];
                        int readBytes = 1;
                        while (readBytes > 0)
                        {
                            readBytes = source.Read(buffer, 0, buffer.Length);
                            destination.Write(buffer, 0, readBytes);
                        }
                    }
                }
            }
        }
    }
}