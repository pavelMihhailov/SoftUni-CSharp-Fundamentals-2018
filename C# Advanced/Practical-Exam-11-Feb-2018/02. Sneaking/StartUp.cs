using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        int rows = int.Parse(Console.ReadLine());
        char[][] room = new char[rows][];
        int[] currSamPosition = new int[2];

        for (int rowIndex = 0; rowIndex < room.Length; rowIndex++)
        {
            room[rowIndex] = Console.ReadLine().ToCharArray();
        }

        bool samKilled = false;
        bool nikoladzeKilled = false;

        int[] samDiedAt = new int[2];

        string commands = Console.ReadLine();

        SearchForSam(room, currSamPosition);

        foreach (var turn in commands)
        {
            samKilled = MoveEnemies(room, samKilled, nikoladzeKilled, samDiedAt);
            if (nikoladzeKilled || samKilled) break;
            if (turn == 'U')
            {
                if (room[currSamPosition[0] - 1][currSamPosition[1]] == 'b' ||
                    room[currSamPosition[0] - 1][currSamPosition[1]] == 'd')
                {
                    room[currSamPosition[0]][currSamPosition[1]] = '.';
                    room[currSamPosition[0] - 1][currSamPosition[1]] = 'S';
                }
                else if (room[currSamPosition[0] - 1][currSamPosition[1]] == '.')
                {
                    room[currSamPosition[0] - 1][currSamPosition[1]] = 'S';
                    room[currSamPosition[0]][currSamPosition[1]] = '.';
                }
                nikoladzeKilled = CheckIfNikoladzeIsOnSameRowUp(room, currSamPosition, nikoladzeKilled);
                currSamPosition[0]--;
            }
            else if (turn == 'D')
            {
                if (room[currSamPosition[0] + 1][currSamPosition[1]] == 'b' ||
                    room[currSamPosition[0] + 1][currSamPosition[1]] == 'd')
                {
                    room[currSamPosition[0]][currSamPosition[1]] = '.';
                    room[currSamPosition[0] + 1][currSamPosition[1]] = 'S';
                }
                else if (room[currSamPosition[0] + 1][currSamPosition[1]] == '.')
                {
                    room[currSamPosition[0] + 1][currSamPosition[1]] = 'S';
                    room[currSamPosition[0]][currSamPosition[1]] = '.';
                }
                nikoladzeKilled = CheckIfNikoladzeIsOnSameRowDown(room, currSamPosition, nikoladzeKilled);
                if (nikoladzeKilled) room[currSamPosition[0]][currSamPosition[1]] = '.';
                currSamPosition[0]++;
            }
            else if (turn == 'L')
            {
                if (room[currSamPosition[0]][currSamPosition[1] - 1] == 'b' ||
                    room[currSamPosition[0]][currSamPosition[1] - 1] == 'd')
                {
                    room[currSamPosition[0]][currSamPosition[1]] = '.';
                    room[currSamPosition[0]][currSamPosition[1] - 1] = 'S';
                }
                else if (room[currSamPosition[0]][currSamPosition[1] - 1] == '.')
                {
                    room[currSamPosition[0]][currSamPosition[1] - 1] = 'S';
                    room[currSamPosition[0]][currSamPosition[1]] = '.';
                }
                currSamPosition[1]--;
            }
            else if (turn == 'R')
            {
                if (room[currSamPosition[0]][currSamPosition[1] + 1] == 'b' ||
                    room[currSamPosition[0]][currSamPosition[1] + 1] == 'd')
                {
                    room[currSamPosition[0]][currSamPosition[1]] = '.';
                    room[currSamPosition[0]][currSamPosition[1] + 1] = 'S';
                }
                else if (room[currSamPosition[0]][currSamPosition[1] + 1] == '.')
                {
                    room[currSamPosition[0]][currSamPosition[1] + 1] = 'S';
                    room[currSamPosition[0]][currSamPosition[1]] = '.';
                }
                currSamPosition[1]++;
            }
        }
        if (nikoladzeKilled)
        {
            Console.WriteLine("Nikoladze killed!");
            for (int i = 0; i < room.Length; i++)
            {
                Console.WriteLine(string.Join("", room[i]));
            }
        }
        if (samKilled)
        {
            Console.WriteLine($"Sam died at {currSamPosition[0]}, {currSamPosition[1]}");
            for (int i = 0; i < room.Length; i++)
            {
                Console.WriteLine(string.Join("", room[i]));
            }
        }
    }

    private static bool CheckIfNikoladzeIsOnSameRowDown(char[][] room, int[] currSamPosition, bool nikoladzeKilled)
    {
        if (room[currSamPosition[0] + 1].Contains('N'))
        {
            nikoladzeKilled = true;
            for (int i = 0; i < room[currSamPosition[0] + 1].Length; i++)
            {
                if (room[currSamPosition[0] + 1][i] == 'N')
                {
                    room[currSamPosition[0] + 1][i] = 'X';
                    break;
                }
            }
        }
        return nikoladzeKilled;
    }
    
    private static bool CheckIfNikoladzeIsOnSameRowUp(char[][] room, int[] currSamPosition, bool nikoladzeKilled)
    {
        if (room[currSamPosition[0] - 1].Contains('N'))
        {
            nikoladzeKilled = true;
            for (int i = 0; i < room[currSamPosition[0] - 1].Length; i++)
            {
                if (room[currSamPosition[0] - 1][i] == 'N')
                {
                    room[currSamPosition[0] - 1][i] = 'X';
                    break;
                }
            }
        }

        return nikoladzeKilled;
    }

    private static bool SearchForSam(char[][] room, int[] currSamPosition)
    {
        bool foundSam = false;
        for (int rowIndex = 0; rowIndex < room.Length; rowIndex++)
        {
            if (foundSam) break;
            for (int colIndex = 0; colIndex < room[rowIndex].Length; colIndex++)
            {
                if (room[rowIndex][colIndex] == 'S')
                {
                    foundSam = true;
                    currSamPosition[0] = rowIndex;
                    currSamPosition[1] = colIndex;
                    break;
                }
            }
        }

        return foundSam;
    }

    private static bool MoveEnemies(char[][] room, bool samKilled, bool nikoladzeKilled, int[] samDiedAt)
    {
        for (int rowIndex = 0; rowIndex < room.Length; rowIndex++)
        {
            bool enemyMoved = false;
            if (nikoladzeKilled) break;
            for (int colIndex = 0; colIndex < room[rowIndex].Length; colIndex++)
            {
                if (room[rowIndex][colIndex] == 'b' || room[rowIndex][colIndex] == 'd') enemyMoved = true;
                samKilled = MoveEnemiesAndIfSamIsOnRangeKillHim(room, samKilled, samDiedAt, rowIndex, colIndex);
                if (enemyMoved) break;
            }
        }
        return samKilled;
    }

    private static bool MoveEnemiesAndIfSamIsOnRangeKillHim(char[][] room, bool samKilled, int[] samDiedAt, int rowIndex, int colIndex)
    {
        if (room[rowIndex][colIndex] == 'b' && colIndex == room[rowIndex].Length - 1)
        {
            room[rowIndex][colIndex] = 'd';
            samKilled = CheckIfSamIsOnSameRow(room, samKilled, samDiedAt, rowIndex);
        }
        else if (room[rowIndex][colIndex] == 'd' && colIndex == 0)
        {
            room[rowIndex][colIndex] = 'b';
            samKilled = CheckIfSamIsOnSameRow(room, samKilled, samDiedAt, rowIndex);
        }
        else if (room[rowIndex][colIndex] == 'b')
        {
            if (room[rowIndex][colIndex + 1] != 'S')
            {
                room[rowIndex][colIndex] = '.';
                room[rowIndex][colIndex + 1] = 'b';

                for (int i = colIndex + 2; i < room[rowIndex].Length; i++)
                {
                    if (room[rowIndex][i] == 'S')
                    {
                        room[rowIndex][i] = 'X';
                        samKilled = true;
                        samDiedAt[0] = rowIndex;
                        samDiedAt[1] = i;
                        break;
                    }
                }
            }
            else
            {
                samKilled = true;
                samDiedAt[0] = rowIndex;
                samDiedAt[1] = colIndex + 1;
                room[rowIndex][colIndex + 1] = 'X';
            }
        }
        else if (room[rowIndex][colIndex] == 'd')
        {
            if (room[rowIndex][colIndex - 1] != 'S')
            {
                room[rowIndex][colIndex] = '.';
                room[rowIndex][colIndex - 1] = 'd';

                for (int i = colIndex - 1 - 1; i >= 0; i--)
                {
                    if (room[rowIndex][i] == 'S')
                    {
                        room[rowIndex][i] = 'X';
                        samKilled = true;
                        samDiedAt[0] = rowIndex;
                        samDiedAt[1] = i;
                        break;
                    }
                }
            }
            else
            {
                samKilled = true;
                samDiedAt[0] = rowIndex;
                samDiedAt[1] = colIndex - 1;
                room[rowIndex][colIndex - 1] = 'X';
            }
        }
        return samKilled;
    }

    private static bool CheckIfSamIsOnSameRow(char[][] room, bool samKilled, int[] samDiedAt, int rowIndex)
    {
        if (room[rowIndex].Contains('S'))
        {
            samKilled = true;
            samDiedAt[0] = rowIndex;
            for (int i = 0; i < room[rowIndex].Length; i++)
            {
                if (room[rowIndex][i] == 'S')
                {
                    samDiedAt[1] = i;
                    room[rowIndex][i] = 'X';
                    break;
                }
            }
        }
        return samKilled;
    }
}
