using System;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        int[] tokens = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToArray();
        int rowsCount = tokens[0];
        int colsCount = tokens[1];
        string snake = Console.ReadLine();
        int[] tokens1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int shotRow = tokens1[0];
        int shotCol = tokens1[1];
        int radius = tokens1[2];

        char[][] stairs = new char[rowsCount][];

        for (int i = 0; i < stairs.Length; i++)
        {
            stairs[i] = new char[colsCount];
        }

        FillStairs(snake, stairs);
        FireShot(shotRow, shotCol, radius, stairs);

        for (int i = 0; i < stairs.Length; i++)
        {
            MoveElements(stairs);
        }
        foreach (var stair in stairs)
        {
            Console.WriteLine(string.Join("", stair));
        }
    }

    private static void MoveElements(char[][] stairs)
    {
        for (int rowIndex = 0; rowIndex < stairs.Length - 1; rowIndex++)
        {
            for (int colIndex = 0; colIndex < stairs[rowIndex].Length; colIndex++)
            {
                if (stairs[rowIndex + 1][colIndex] == ' ')
                {
                    stairs[rowIndex + 1][colIndex] = stairs[rowIndex][colIndex];
                    stairs[rowIndex][colIndex] = ' ';
                }
            }
        }
    }

    private static void FireShot(int shotRow, int shotCol, int radius, char[][] stairs)
    {
        for (int rowIndex = 0; rowIndex < stairs.Length; rowIndex++)
        {
            for (int colIndex = 0; colIndex < stairs[rowIndex].Length; colIndex++)
            {
                double currPoint = Math.Pow(rowIndex - shotRow, 2) + Math.Pow(colIndex - shotCol, 2);
                double inRadius = Math.Pow(radius, 2);
                if (currPoint <= inRadius) stairs[rowIndex][colIndex] = ' ';
            }
        }
    }

    private static void FillStairs(string snake, char[][] stairs)
    {
        int countRows = 1;
        int charsCount = 0;

        while (countRows <= stairs.Length)
        {
            int rowIndex = stairs.Length - countRows;
            if (countRows % 2 != 0)
            {
                for (int colIndex = stairs[rowIndex].Length - 1; colIndex >= 0; colIndex--)
                {
                    if (charsCount >= snake.Length) charsCount = 0;
                    stairs[rowIndex][colIndex] = snake[charsCount];
                    charsCount++;
                }
                countRows++;
            }
            else
            {
                for (int colIndex = 0; colIndex < stairs[rowIndex].Length; colIndex++)
                {
                    if (charsCount >= snake.Length) charsCount = 0;
                    stairs[rowIndex][colIndex] = snake[charsCount];
                    charsCount++;
                }
                countRows++;
            }
        }
    }
}

