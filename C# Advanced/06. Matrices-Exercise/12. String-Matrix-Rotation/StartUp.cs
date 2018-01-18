using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        string[] input = Console.ReadLine().Split('(');
        int rotate = int.Parse(input[1].TrimEnd(')'));
        List<string> sequence = new List<string>();
        int longestWord = 0;

        string command = Console.ReadLine().Trim();

        while (true)
        {
            if (command == "END") break;

            sequence.Add(command);
            if (command.Length > longestWord) longestWord = command.Length;
            command = Console.ReadLine();
        }

        for (int i = 0; i < sequence.Count; i++)
        {
            if (sequence[i].Length < longestWord)
                sequence[i] = sequence[i] + new string(' ', longestWord - sequence[i].Length);
        }

        if (rotate % 360 == 180)
        {
            for (int i = sequence.Count - 1; i >= 0; i--)
            {
                for (int j = sequence[i].Length - 1; j >= 0; j--)
                {
                    Console.Write(sequence[i][j]);
                }
                Console.WriteLine();
            }
        }
        var matrix = new char[longestWord, sequence.Count];
        //make matrix
        for (int rowIndex = 0; rowIndex < matrix.GetLength(0); rowIndex++)
        {
            for (int colIndex = 0; colIndex < matrix.GetLength(1); colIndex++)
            {
                matrix[rowIndex, colIndex] = sequence[colIndex][rowIndex];
            }
        }

        if (rotate % 360 == 90)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = matrix.GetLength(1) - 1; j >= 0; j--)
                {
                    Console.Write($"{matrix[i, j]}");
                }
                Console.WriteLine();
            }
        }
        else if (rotate % 360 == 270)
        {
            for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]}");
                }
                Console.WriteLine();
            }
        }
        else if (rotate % 360 == 0)
        {
            foreach (var row in sequence)
            {
                Console.WriteLine(string.Join("", row));
            }
        }
    }
}
