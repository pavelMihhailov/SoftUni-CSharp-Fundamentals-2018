using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        using (var readStream = new StreamReader("Program.cs"))
        {
            int cnt = 1;
            string line = readStream.ReadLine();
            while (line != null)
            {
                Console.WriteLine($"Line {cnt}: {line}");
                cnt++;
                line = readStream.ReadLine();
            }
        }
    }
}
