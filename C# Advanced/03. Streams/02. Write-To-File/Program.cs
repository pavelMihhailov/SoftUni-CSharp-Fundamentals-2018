using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        using (var readStream = new StreamReader("Program.cs"))
        {
            using (var writeStream = new StreamWriter("reversed.txt"))
            {
                string line = readStream.ReadLine();
                while (line != null)
                {
                    for (int i = line.Length - 1; i >= 0; i--)
                    {
                        writeStream.Write(line[i]);
                    }
                    writeStream.WriteLine();
                    line = readStream.ReadLine();
                }
            }
        }
    }
}
