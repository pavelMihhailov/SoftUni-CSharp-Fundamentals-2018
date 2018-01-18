using System;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var tokens = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToArray();
        var lairRows = tokens[0];
        var lairCols = tokens[1];
        var lair = new char[lairRows][];
        var playerIndex = new int[2];

        FillLair(lairRows, lairCols, lair, playerIndex);
        var playerRow = playerIndex[0];
        var playerCol = playerIndex[1];

        var commands = Console.ReadLine();

        var playerDied = false;
        var playerWon = false;

        for (var i = 0; i < commands.Length; i++)
        {
            if (playerDied == false)
                MovePlayer(lairRows, lairCols, lair, ref playerRow, ref playerCol, commands, ref playerDied,
                    ref playerWon, i);
            playerDied = SpreadBunnies(lair, playerDied);

            if (playerDied || playerWon) break;
        }

        foreach (var row in lair)
            Console.WriteLine(string.Join("", row));
        if (playerWon) Console.WriteLine($"won: {playerRow} {playerCol}");
        if (playerDied) Console.WriteLine($"dead: {playerRow} {playerCol}");
    }

    private static bool SpreadBunnies(char[][] lair, bool playerDied)
    {
        for (var rowIndex = 0; rowIndex < lair.Length; rowIndex++)
        for (var colIndex = 0; colIndex < lair[rowIndex].Length; colIndex++)
            if (lair[rowIndex][colIndex] == 'B')
            {
                //Left
                if (colIndex > 0 && lair[rowIndex][colIndex - 1] != 'B')
                {
                    if (lair[rowIndex][colIndex - 1] == 'P') playerDied = true;
                    lair[rowIndex][colIndex - 1] = 'b';
                }
                //Right
                if (colIndex < lair[rowIndex].Length - 1 && lair[rowIndex][colIndex + 1] != 'B')
                {
                    if (lair[rowIndex][colIndex + 1] == 'P') playerDied = true;
                    lair[rowIndex][colIndex + 1] = 'b';
                }
                //Up
                if (rowIndex > 0 && lair[rowIndex - 1][colIndex] != 'B')
                {
                    if (lair[rowIndex - 1][colIndex] == 'P') playerDied = true;
                    lair[rowIndex - 1][colIndex] = 'b';
                }
                //Down
                if (rowIndex < lair.Length - 1 && lair[rowIndex + 1][colIndex] != 'B')
                {
                    if (lair[rowIndex + 1][colIndex] == 'P') playerDied = true;
                    lair[rowIndex + 1][colIndex] = 'b';
                }
            }
        for (var j = 0; j < lair.Length; j++)
        for (var k = 0; k < lair[j].Length; k++)
            if (lair[j][k] == 'b') lair[j][k] = 'B';
        return playerDied;
    }

    private static void MovePlayer(int lairRows, int lairCols, char[][] lair, ref int playerRow, ref int playerCol,
        string commands, ref bool playerDied, ref bool playerWon, int i)
    {
        if (commands[i] == 'L')
        {
            if (playerCol - 1 < 0)
            {
                lair[playerRow][playerCol] = '.';
                playerWon = true;
            }

            if (!playerWon)
            {
                if (lair[playerRow][playerCol - 1] == '.')
                {
                    lair[playerRow][playerCol - 1] = 'P';
                    lair[playerRow][playerCol] = '.';
                }
                else playerDied = true;
                playerCol--;
            }
        }
        else if (commands[i] == 'R')
        {
            if (playerCol + 1 > lairCols - 1)
            {
                lair[playerRow][playerCol] = '.';
                playerWon = true;
            }

            if (!playerWon)
            {
                if (lair[playerRow][playerCol + 1] == '.')
                {
                    lair[playerRow][playerCol + 1] = 'P';
                    lair[playerRow][playerCol] = '.';
                }
                else playerDied = true;
                playerCol++;
            }
        }
        else if (commands[i] == 'U')
        {
            if (playerRow - 1 < 0)
            {
                lair[playerRow][playerCol] = '.';
                playerWon = true;
            }

            if (!playerWon)
            {
                if (lair[playerRow - 1][playerCol] == '.')
                {
                    lair[playerRow - 1][playerCol] = 'P';
                    lair[playerRow][playerCol] = '.';
                }
                else playerDied = true;
                playerRow--;
            }
        }
        else if (commands[i] == 'D')
        {
            if (playerRow + 1 > lair.Length - 1)
            {
                lair[playerRow][playerCol] = '.';
                playerWon = true;
            }

            if (!playerWon)
                if (lair[playerRow + 1][playerCol] == '.')
                {
                    lair[playerRow + 1][playerCol] = 'P';
                    lair[playerRow][playerCol] = '.';
                    playerRow++;
                }
                else
                {
                    playerRow--;
                    playerDied = true;
                }
        }
    }

    private static void FillLair(int lairRows, int lairCols, char[][] lair, int[] playerIndex)
    {
        for (var rowIndex = 0; rowIndex < lairRows; rowIndex++)
        {
            lair[rowIndex] = new char[lairCols];

            var symbol = Console.ReadLine();
            for (var colIndex = 0; colIndex < lair[rowIndex].Length; colIndex++)
            {
                lair[rowIndex][colIndex] = symbol[colIndex];
                if (symbol[colIndex] == 'P')
                {
                    playerIndex[0] = rowIndex;
                    playerIndex[1] = colIndex;
                }
            }
        }
    }
}