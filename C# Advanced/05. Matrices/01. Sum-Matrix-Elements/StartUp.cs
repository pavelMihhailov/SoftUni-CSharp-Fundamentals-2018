using System;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        int[] matrixSize = Console.ReadLine().Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToArray();
        int rows = matrixSize[0];
        int cols = matrixSize[1];
        int sum = 0;

        int[][] matrix = new int[rows][];

        for (int rowIndex = 0; rowIndex < rows; rowIndex++)
        {
            int[] inputNums = Console.ReadLine().Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            matrix[rowIndex] = inputNums;
            sum += matrix[rowIndex].Sum();
        }
        Console.WriteLine($"{rows}\n{cols}\n{sum}");
    }
}
