using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        int[] matrixSize = Console.ReadLine().Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToArray();
        int rows = matrixSize[0];

        int[][] matrix = new int[rows][];
        int maxSum = int.MinValue;
        int rowIndexOfMax = 0;
        int colIndexOfMax = 0;

        for (int rowIndex = 0; rowIndex < rows; rowIndex++)
        {
            int[] inputNums = Console.ReadLine().Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            matrix[rowIndex] = inputNums;
        }

        for (int rowIndex = 0; rowIndex < rows - 1; rowIndex++)
        {
            for (int colIndex = 0; colIndex < matrixSize[1] - 1; colIndex++)
            {
                int currentSum = 0;
                currentSum = matrix[rowIndex][colIndex] + matrix[rowIndex][colIndex + 1] +
                             matrix[rowIndex + 1][colIndex] + matrix[rowIndex + 1][colIndex + 1];

                if (currentSum > maxSum)
                {
                    rowIndexOfMax = rowIndex;
                    colIndexOfMax = colIndex;
                    maxSum = currentSum;
                }
            }
        }
        Console.WriteLine($"{matrix[rowIndexOfMax][colIndexOfMax]} {matrix[rowIndexOfMax][colIndexOfMax + 1]}");
        Console.WriteLine($"{matrix[rowIndexOfMax + 1][colIndexOfMax]} {matrix[rowIndexOfMax + 1][colIndexOfMax + 1]}");
        Console.WriteLine(maxSum);
    }
}
