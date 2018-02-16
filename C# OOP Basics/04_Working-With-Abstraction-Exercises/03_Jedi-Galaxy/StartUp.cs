﻿using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] dimestions = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        int x = dimestions[0];
        int y = dimestions[1];

        int[,] matrix = new int[x, y];

        FillMatrix(x, y, matrix);

        string command = Console.ReadLine();
        long sum = 0;

        while (command != "Let the Force be with you")
        {
            int[] ivoS = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] evil = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int xE = evil[0];
            int yE = evil[1];

            MakeZeroPointsWhereEvilSteps(matrix, ref xE, ref yE);

            int xI = ivoS[0];
            int yI = ivoS[1];

            CollectStars(matrix, ref sum, ref xI, ref yI);

            command = Console.ReadLine();
        }
        Console.WriteLine(sum);
    }

    private static void CollectStars(int[,] matrix, ref long sum, ref int xI, ref int yI)
    {
        while (xI >= 0 && yI < matrix.GetLength(1))
        {
            if (xI >= 0 && xI < matrix.GetLength(0) && yI >= 0 && yI < matrix.GetLength(1))
            {
                sum += matrix[xI, yI];
            }
            yI++;
            xI--;
        }
    }

    private static void MakeZeroPointsWhereEvilSteps(int[,] matrix, ref int xE, ref int yE)
    {
        while (xE >= 0 && yE >= 0)
        {
            if (xE >= 0 && xE < matrix.GetLength(0) && yE >= 0 && yE < matrix.GetLength(1))
            {
                matrix[xE, yE] = 0;
            }
            xE--;
            yE--;
        }
    }

    private static void FillMatrix(int x, int y, int[,] matrix)
    {
        int value = 0;
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                matrix[i, j] = value++;
            }
        }
    }
}