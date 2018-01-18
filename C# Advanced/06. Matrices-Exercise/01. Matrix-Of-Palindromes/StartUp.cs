using System;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        int[] tokens = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int rows = tokens[0];
        int cols = tokens[1];
        char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        string[][] matrix = new string[rows][];

        for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
        {
            matrix[rowIndex] = new string[cols];
            for (int colIndex = 0; colIndex < matrix[rowIndex].Length; colIndex++)
            {
                int sum = rowIndex + colIndex;
                matrix[rowIndex][colIndex] = alphabet[rowIndex].ToString() + alphabet[sum] + alphabet[rowIndex];
            }
        }
        foreach (var row in matrix)
        {
            Console.WriteLine(string.Join(" ", row));
        }
    }
}
