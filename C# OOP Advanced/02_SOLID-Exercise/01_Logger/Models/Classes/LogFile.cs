using System;
using System.IO;

public class LogFile : ILogFile
{
    public LogFile(string fileName)
    {
        Path = DefaultPath + fileName;
        InitializeFile();
        Size = 0;
    }

    private void InitializeFile()
    {
        Directory.CreateDirectory(DefaultPath);
        File.AppendAllText(Path, "");
    }

    private const string DefaultPath = "./data/";

    public string Path { get; }

    public int Size { get; private set; }

    public void WriteToFile(string errorLog)
    {
        File.AppendAllText(Path, errorLog + Environment.NewLine);

        int addedSize = 0;
        for (int i = 0; i < errorLog.Length; i++)
        {
            addedSize += errorLog[i];
        }

        Size += addedSize;
    }
}
