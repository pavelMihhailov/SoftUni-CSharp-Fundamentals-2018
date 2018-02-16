using System;

class Sneaking
{
    static char[][] room;
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        room = new char[n][];

        int[] samPosition = new int[2];

        FillRoomAndGetSamPosition(n, samPosition);

        var moves = Console.ReadLine().ToCharArray();

        for (int i = 0; i < moves.Length; i++)
        {
            for (int row = 0; row < room.Length; row++)
                MoveEnemies(row);

            int[] nikoladzePosition = new int[2];
            GetNikoladzePosition(samPosition, nikoladzePosition);

            if (samPosition[1] < nikoladzePosition[1] && room[nikoladzePosition[0]][nikoladzePosition[1]] == 'd' && nikoladzePosition[0] == samPosition[0])
            {
                PrintRoomCuzSamDied(samPosition);
                return;
            }
            if (nikoladzePosition[1] < samPosition[1] && room[nikoladzePosition[0]][nikoladzePosition[1]] == 'b' && nikoladzePosition[0] == samPosition[0])
            {
                PrintRoomCuzSamDied(samPosition);
                return;
            }

            MoveSam(samPosition, moves, i);

            GetNikoladzePosition(samPosition, nikoladzePosition);
            if (room[nikoladzePosition[0]][nikoladzePosition[1]] == 'N' && samPosition[0] == nikoladzePosition[0])
            {
                PrintRoomCuzEnemyDied(nikoladzePosition);
            }
        }
    }

    private static void MoveSam(int[] samPosition, char[] moves, int i)
    {
        room[samPosition[0]][samPosition[1]] = '.';
        switch (moves[i])
        {
            case 'U':
                samPosition[0]--;
                break;
            case 'D':
                samPosition[0]++;
                break;
            case 'L':
                samPosition[1]--;
                break;
            case 'R':
                samPosition[1]++;
                break;
            default:
                break;
        }
        room[samPosition[0]][samPosition[1]] = 'S';
    }

    private static void PrintRoomCuzEnemyDied(int[] nikoladzePosition)
    {
        room[nikoladzePosition[0]][nikoladzePosition[1]] = 'X';
        Console.WriteLine("Nikoladze killed!");
        for (int row = 0; row < room.Length; row++)
        {
            for (int col = 0; col < room[row].Length; col++)
            {
                Console.Write(room[row][col]);
            }
            Console.WriteLine();
        }
        Environment.Exit(0);
    }

    private static void PrintRoomCuzSamDied(int[] samPosition)
    {
        room[samPosition[0]][samPosition[1]] = 'X';
        Console.WriteLine($"Sam died at {samPosition[0]}, {samPosition[1]}");
        for (int row = 0; row < room.Length; row++)
        {
            for (int col = 0; col < room[row].Length; col++)
            {
                Console.Write(room[row][col]);
            }
            Console.WriteLine();
        }
        Environment.Exit(0);
    }

    private static void GetNikoladzePosition(int[] samPosition, int[] nikoladzePosition)
    {
        for (int j = 0; j < room[samPosition[0]].Length; j++)
        {
            if (room[samPosition[0]][j] != '.' && room[samPosition[0]][j] != 'S')
            {
                nikoladzePosition[0] = samPosition[0];
                nikoladzePosition[1] = j;
            }
        }
    }

    private static void MoveEnemies(int row)
    {
        for (int col = 0; col < room[row].Length; col++)
        {
            if (room[row][col] == 'b')
            {
                if (row >= 0 && row < room.Length && col + 1 >= 0 && col + 1 < room[row].Length)
                {
                    room[row][col] = '.';
                    room[row][col + 1] = 'b';
                    col++;
                }
                else
                {
                    room[row][col] = 'd';
                }
            }
            else if (room[row][col] == 'd')
            {
                if (row >= 0 && row < room.Length && col - 1 >= 0 && col - 1 < room[row].Length)
                {
                    room[row][col] = '.';
                    room[row][col - 1] = 'd';
                }
                else
                {
                    room[row][col] = 'b';
                }
            }
        }
    }

    private static void FillRoomAndGetSamPosition(int n, int[] samPosition)
    {
        for (int row = 0; row < n; row++)
        {
            var input = Console.ReadLine().ToCharArray();
            room[row] = new char[input.Length];
            for (int col = 0; col < input.Length; col++)
            {
                room[row][col] = input[col];
                if (room[row][col] == 'S')
                {
                    samPosition[0] = row;
                    samPosition[1] = col;
                }
            }
        }
    }
}