using System.IO;

class Program
{
    static void Main()
    {
        using (FileStream sourceFile = new FileStream("copyMe.png", FileMode.Open))
        {
            using (FileStream destinationFile = new FileStream("copied-CopyMe.png", FileMode.Create))
            {
                byte[] buffer = new byte[4096];
                while (true)
                {
                    int readBytes = sourceFile.Read(buffer, 0, buffer.Length);

                    if (readBytes == 0) break;
                    destinationFile.Write(buffer, 0, readBytes);
                }
            }
        }
    }
}
