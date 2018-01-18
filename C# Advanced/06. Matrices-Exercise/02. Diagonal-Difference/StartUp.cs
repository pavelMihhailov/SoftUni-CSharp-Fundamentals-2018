using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        int sizeMatrix = int.Parse(Console.ReadLine());
        int[][] matrix = new int[sizeMatrix][];
        
        int sumPrimary = 0;
        int sumSecondary = 0;
        
        for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
        {
            matrix[rowIndex] = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
        
            for (int colIndex = 0; colIndex < matrix[rowIndex].Length; colIndex++)
            {
                if (rowIndex == colIndex) sumPrimary += matrix[rowIndex][colIndex];
                if (colIndex == sizeMatrix - 1) sumSecondary += matrix[rowIndex][colIndex];
            }
            sizeMatrix--;
        }
        int diff = Math.Abs(sumPrimary - sumSecondary);
        Console.WriteLine(diff);
    }
}
