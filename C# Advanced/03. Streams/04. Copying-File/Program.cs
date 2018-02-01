using System.IO;

class Program
{
    static void Main(string[] args)
    {
        using (var source = new FileStream("bentley.jpg", FileMode.Open))
        {
            using (var destination = new FileStream("bentley-Copy.jpg", FileMode.Create))
            {
                byte[] buffer = new byte[4096];
                while (true)
                {
                    int readBytes = source.Read(buffer, 0, buffer.Length);
                    if (readBytes == 0) break;
                    destination.Write(buffer, 0, readBytes);
                }
            }
        }
    }
}
