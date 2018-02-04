using System;
using System.Linq;

namespace _02._Monopoly
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];
            char[][] table = new char[rows][];

            MakeTable(rows, cols, table);

            int hotels = 0;
            int money = 50;
            int turns = 0;

            for (int row = 0; row < table.Length; row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < table[row].Length; col++)
                    {
                        Turns(table, ref hotels, ref money, ref turns, row, col);
                    }
                }
                else
                {
                    for (int col = table[row].Length - 1; col >= 0; col--)
                    {
                        Turns(table, ref hotels, ref money, ref turns, row, col);
                    }
                }
            }
            Console.WriteLine($"Turns {turns}");
            Console.WriteLine($"Money {money}");
        }

        private static void Turns(char[][] table, ref int hotels, ref int money, ref int turns, int row, int col)
        {
            switch (table[row][col])
            {
                case 'H':
                    {
                        hotels++;
                        Console.WriteLine($"Bought a hotel for {money}. Total hotels: {hotels}.");
                        money = 0;
                    }
                    break;
                case 'J':
                    {
                        Console.WriteLine($"Gone to jail at turn {turns}.");
                        turns += 2;
                        money += 2 * (hotels * 10);
                    }
                    break;
                case 'S':
                    {
                        int spent = (row + 1) * (col + 1);
                        if (spent <= money)
                        {
                            Console.WriteLine($"Spent {spent} money at the shop.");
                            money -= spent;
                        }
                        else
                        {
                            Console.WriteLine($"Spent {money} money at the shop.");
                            money = 0;
                        }
                    }
                    break;
            }
            money += hotels * 10;
            turns++;
        }

        private static void MakeTable(int rows, int cols, char[][] table)
        {
            for (int i = 0; i < rows; i++)
            {
                table[i] = new char[cols];
                string moves = Console.ReadLine();
                for (int j = 0; j < moves.Length; j++)
                {
                    table[i][j] = moves[j];
                }
            }
        }
    }
}
