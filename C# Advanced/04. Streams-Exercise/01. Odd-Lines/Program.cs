using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        using (var readStream = new StreamReader("text.txt"))
        {
            int cnt = 0;
            string text = readStream.ReadLine();
            while (text != null)
            {
                if (cnt % 2 != 0) Console.WriteLine(text);
                cnt++;
                text = readStream.ReadLine();
            }
        }
    }
}
