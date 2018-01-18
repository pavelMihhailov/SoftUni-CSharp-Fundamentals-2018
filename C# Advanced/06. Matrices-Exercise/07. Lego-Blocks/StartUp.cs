using System;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[][] firstMatrix = new int[n][];
        int[][] secondMatrix = new int[n][];
        int[][] completeMatrix = new int[n][];
        int countElements = 0;

        FillMatrix(n, firstMatrix);
        FillMatrix(n, secondMatrix);

        ReverseSecond(secondMatrix);
        countElements = AllCellsCount(firstMatrix, secondMatrix);

        bool fit = true;
        fit = TryToFit(firstMatrix, secondMatrix, countElements, fit);
        if (fit)
        {
            FitAndPrint(n, firstMatrix, secondMatrix, completeMatrix);
        }
    }

    private static bool TryToFit(int[][] firstMatrix, int[][] secondMatrix, int countElements, bool fit)
    {
        int countCols = firstMatrix[0].Length + secondMatrix[0].Length;
        for (int rowIndex = 1; rowIndex < firstMatrix.Length; rowIndex++)
        {
            int currCols = firstMatrix[rowIndex].Length + secondMatrix[rowIndex].Length;
            if (currCols != countCols)
            {
                Console.WriteLine($"The total number of cells is: {countElements}");
                fit = false;
                break;
            }
        }
        return fit;
    }

    private static int AllCellsCount(int[][] firstMatrix, int[][] secondMatrix)
    {
        var sum = 0;
        for (var i = 0; i < firstMatrix.Length; i++)
        {
            sum += firstMatrix[i].Length + secondMatrix[i].Length;
        }
        return sum;
    }

    private static void ReverseSecond(int[][] secondMatrix)
    {
        for (int i = 0; i < secondMatrix.Length; i++)
        {
            Array.Reverse(secondMatrix[i]);
        }
    }

    private static void FillMatrix(int n, int[][] firstMatrix)
    {
        for (int i = 0; i < n; i++)
        {
            int[] numbers = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            firstMatrix[i] = numbers;
        }
    }

    private static void FitAndPrint(int n, int[][] firstMatrix, int[][] secondMatrix, int[][] completeMatrix)
    {
        for (int i = 0; i < n; i++)
        {
            completeMatrix[i] = new int[firstMatrix[i].Length + secondMatrix[i].Length];
        }
        
        for (int rowIndex = 0; rowIndex < completeMatrix.Length; rowIndex++)
        {
            int lastElOfFirst = firstMatrix[rowIndex].Length;
            int cntSecond = 0;
            for (int colIndex = 0; colIndex < completeMatrix[rowIndex].Length; colIndex++)
            {
                if (colIndex < lastElOfFirst)
                {
                    completeMatrix[rowIndex][colIndex] = firstMatrix[rowIndex][colIndex];
                }
                else
                {
                    completeMatrix[rowIndex][colIndex] = secondMatrix[rowIndex][cntSecond];
                    cntSecond++;
                }
            }
        }
        foreach (var row in completeMatrix)
        {
            Console.WriteLine($"[{string.Join(", ", row)}]");
        }
    }
}
