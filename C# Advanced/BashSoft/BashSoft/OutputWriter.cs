using System;
using System.Collections.Generic;

public static class OutputWriter
{
    public static void WriteMessage(string message)
    {
        Console.Write(message);
    }

    public static void WriteMessageonNewLine(string message)
    {
        Console.WriteLine(message);
    }

    public static void WriteEmptyLine()
    {
        Console.WriteLine();
    }

    public static void DisplayException(string message)
    {
        ConsoleColor currentColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ForegroundColor = currentColor;
    }

    public static void PrintStudent(KeyValuePair<string, List<int>> student)
    {
        WriteMessageonNewLine(string.Format($"{student.Key} - {string.Join(", ", student.Value)}"));
    }
}

