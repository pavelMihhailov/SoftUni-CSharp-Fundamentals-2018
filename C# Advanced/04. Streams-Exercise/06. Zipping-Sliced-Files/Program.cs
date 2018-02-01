using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace _06.Zipping_Sliced_Files
{
    public class ZippingSlicedFiles
    {
        public static void Main()
        {
            Console.Write("Choose to how many parts to slice the file: ");
            var parts = int.Parse(Console.ReadLine());
            var directory = "../../sliced files/";

            SliceAndCompress("video.flv", directory, parts);
            var slicedFiles = new List<string>(Directory.GetFiles(directory));
            DecompressAndAssemble(slicedFiles, "../../");
        }

        public static void SliceAndCompress(string sourceFile, string destinationDirectory, int parts)
        {
            Directory.CreateDirectory(destinationDirectory);
            using (var source = new FileStream(sourceFile, FileMode.Open))
            {
                var buffer = new byte[source.Length / parts + source.Length % parts];

                int readBytes = 0, count = 1;
                while ((readBytes = source.Read(buffer, 0, buffer.Length)) > 0)
                {
                    var destinationFilePath = $"{destinationDirectory}/Part -{count.ToString()}.gz";
                    using (var destination = new FileStream(destinationFilePath, FileMode.Create))
                    {
                        using (var compressStream = new GZipStream(destination, CompressionMode.Compress, false))
                        {
                            compressStream.Write(buffer, 0, buffer.Length);
                        }
                    }
                    count++;
                }
            }
        }

        public static void DecompressAndAssemble(List<string> files, string destinationDirectory)
        {
            Directory.CreateDirectory(destinationDirectory);
            var destinationFilename = $"{destinationDirectory}assembled.flv";

            using (var destination = new FileStream(destinationFilename, FileMode.Create))
                foreach (var filename in files)
                {
                    using (var source = new FileStream(filename, FileMode.Open))
                    using (var decompressStream = new GZipStream(source, CompressionMode.Decompress, false))
                    {
                        var buffer = new byte[4096];
                        int readBytes;
                        while ((readBytes = decompressStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            destination.Write(buffer, 0, readBytes);
                        }
                    }
                }
        }
    }
}