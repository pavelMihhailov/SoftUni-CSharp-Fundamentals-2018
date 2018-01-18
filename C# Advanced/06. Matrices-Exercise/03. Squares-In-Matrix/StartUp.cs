using System;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        int[] tokens = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToArray();
        int rows = tokens[0];
        int cols = tokens[1];

        int squaresFound = 0;

        char[][] matrix = new char[rows][];

        for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
        {
            matrix[rowIndex] = new char[cols];
            matrix[rowIndex] = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
        }

        for (int row = 0; row < matrix.Length; row++)
        {
            for (int col = 0; col < matrix[row].Length - 1; col++)
            {
                if (row != matrix.Length - 1)
                {
                    if (matrix[row][col] == matrix[row][col + 1] && matrix[row + 1][col] == matrix[row + 1][col + 1]
                        && matrix[row][col + 1] == matrix[row + 1][col])
                        squaresFound++;
                }
            }
        }
        Console.WriteLine(squaresFound);
    }
}
