using System;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        int[] rowsCols = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToArray();

        int[][] matrix = new int[rowsCols[0]][];

        for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
        {
            matrix[rowIndex] = new int[rowsCols[1]];
            matrix[rowIndex] = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
        }

        int maxSum = int.MinValue;
        int rowIndexMax = 0;
        int colIndexMax = 0;

        for (int row = 0; row < matrix.Length - 2; row++)
        {
            for (int col = 0; col < matrix[row].Length - 2; col++)
            {
                int currSum = matrix[row][col] + matrix[row][col + 1] + matrix[row][col + 2] +
                              matrix[row + 1][col] + matrix[row + 1][col + 1] + matrix[row + 1][col + 2] +
                              matrix[row + 2][col] + matrix[row + 2][col + 1] + matrix[row + 2][col + 2];
                if (currSum > maxSum)
                {
                    maxSum = currSum;
                    rowIndexMax = row;
                    colIndexMax = col;
                }
            }
        }

        Console.WriteLine($"Sum = {maxSum}");
        Console.WriteLine(
            $"{matrix[rowIndexMax][colIndexMax]} {matrix[rowIndexMax][colIndexMax + 1]} {matrix[rowIndexMax][colIndexMax + 2]}\n{matrix[rowIndexMax + 1][colIndexMax]} {matrix[rowIndexMax + 1][colIndexMax + 1]} {matrix[rowIndexMax + 1][colIndexMax + 2]}\n{matrix[rowIndexMax + 2][colIndexMax]} {matrix[rowIndexMax + 2][colIndexMax + 1]} {matrix[rowIndexMax + 2][colIndexMax + 2]}");
    }
}
