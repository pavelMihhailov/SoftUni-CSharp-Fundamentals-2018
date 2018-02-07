using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        int[] coordsGalaxy = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToArray();
        int[][] galaxy = new int[coordsGalaxy[0]][];

        MakeGalaxy(coordsGalaxy, galaxy);

        long ivoPoints = 0;

        while (true)
        {
            string command = Console.ReadLine();
            if (command == "Let the Force be with you") break;

            int[] ivoCoords = command.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int[] evilCoords = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            MakeEvilIndexes0Points(galaxy, evilCoords);
            ivoPoints += CalcSumOfStars(galaxy, ivoCoords);
        }
        Console.WriteLine(ivoPoints);
    }

    private static void MakeEvilIndexes0Points(int[][] galaxy, int[] evilCoords)
    {
        int evilRow = evilCoords[0];
        int evilCol = evilCoords[1];
        
        if (evilCol < 0) return;

        while (evilRow >= 0 && evilCol >= 0)
        {
            if (evilRow < galaxy.Length && evilCol < galaxy[0].Length) galaxy[evilRow][evilCol] = 0;
            evilCol--;
            evilRow--;
        }
    }

    private static long CalcSumOfStars(int[][] galaxy, int[] ivoCoords)
    {
        int ivoRow = ivoCoords[0];
        int ivoCol = ivoCoords[1];

        long sum = 0;
        while (ivoRow >= 0 && ivoCol <= galaxy[0].Length - 1)
        {
            if (ivoRow < galaxy.Length && ivoCol >= 0) sum += galaxy[ivoRow][ivoCol];
            ivoRow--;
            ivoCol++;
        }
        return sum;
    }

    private static void MakeGalaxy(int[] coordsGalaxy, int[][] galaxy)
    {
        int fillNum = 0;
        for (int row = 0; row < galaxy.Length; row++)
        {
            galaxy[row] = new int[coordsGalaxy[1]];
            for (int col = 0; col < galaxy[row].Length; col++)
            {
                galaxy[row][col] = fillNum;
                fillNum++;
            }
        }
    }
}
