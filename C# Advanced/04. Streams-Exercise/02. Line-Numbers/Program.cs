using System.IO;

class Program
{
    static void Main(string[] args)
    {
        using (var readStream = new StreamReader("text.txt"))
        {
            using (var writeStream = new StreamWriter("newText.txt"))
            {
                string line = readStream.ReadLine();
                int cnt = 0;
                while (line != null)
                {
                    writeStream.WriteLine($"Line {cnt}: {line}");
                    cnt++;
                    line = readStream.ReadLine();
                }
            }
        }
    }
}
