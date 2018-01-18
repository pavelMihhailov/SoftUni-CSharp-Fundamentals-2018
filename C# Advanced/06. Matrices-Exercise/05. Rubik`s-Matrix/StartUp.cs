using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        int[] tokens = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int rows = tokens[0];
        int cols = tokens[1];
        int commands = int.Parse(Console.ReadLine());
        int[][] rubicCube = new int[rows][];
        int num = 1;

        for (int row = 0; row < rubicCube.Length; row++)
        {
            rubicCube[row] = new int[cols];
            for (int col = 0; col < rubicCube[row].Length; col++)
            {
                rubicCube[row][col] = num;
                num++;
            }
        }

        for (int i = 0; i < commands; i++)
        {
            string[] command = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            string direction = command[1];
            int rowCol = int.Parse(command[0]);
            int moves = int.Parse(command[2]);

            if (direction == "up")
            {
                Queue<int> queue = new Queue<int>();
                for (int j = 0; j < rubicCube.Length; j++)
                {
                    queue.Enqueue(rubicCube[j][rowCol]);
                }
                Shuffle(moves, queue);
                for (int j = 0; j < rubicCube.Length; j++)
                {
                    rubicCube[j][rowCol] = queue.Dequeue();
                }
            }
            else if (direction == "down")
            {
                Queue<int> queue = new Queue<int>();
                for (int j = rubicCube.Length - 1; j >= 0; j--)
                {
                    queue.Enqueue(rubicCube[j][rowCol]);
                }
                Shuffle(moves, queue);
                for (int j = rubicCube.Length - 1; j >= 0; j--)
                {
                    rubicCube[j][rowCol] = queue.Dequeue();
                }
            }
            else if (direction == "left")
            {
                Queue<int> queue = new Queue<int>();
                for (int j = 0; j < rubicCube[rowCol].Length; j++)
                {
                    queue.Enqueue(rubicCube[rowCol][j]);
                }
                Shuffle(moves, queue);
                for (int j = 0; j < rubicCube[rowCol].Length; j++)
                {
                    rubicCube[rowCol][j] = queue.Dequeue();
                }
            }
            else if (direction == "right")
            {
                Queue<int> queue = new Queue<int>();
                for (int j = rubicCube[rowCol].Length - 1; j >= 0; j--)
                {
                    queue.Enqueue(rubicCube[rowCol][j]);
                }
                Shuffle(moves, queue);
                for (int j = rubicCube[rowCol].Length - 1; j >= 0; j--)
                {
                    rubicCube[rowCol][j] = queue.Dequeue();
                }
            }
        }
        RearrangeMatrix(rubicCube);
    }

    private static void RearrangeMatrix(int[][] rubicCube)
    {
        int counter = 1;
        for (int row = 0; row < rubicCube.Length; row++)
        {
            for (int col = 0; col < rubicCube[row].Length; col++)
            {
                if (rubicCube[row][col] == counter) Console.WriteLine("No swap required");
                else
                {
                    long indexRowToReplace = 0;
                    long indexColToReplace = 0;
                    for (long rowIndex = 0; rowIndex < rubicCube.Length; rowIndex++)
                    {
                        for (long colIndex = 0; colIndex < rubicCube[rowIndex].Length; colIndex++)
                        {
                            if (rubicCube[rowIndex][colIndex] == counter)
                            {
                                indexRowToReplace = rowIndex;
                                indexColToReplace = colIndex;
                            }
                        }
                    }
                    rubicCube[indexRowToReplace][indexColToReplace] = rubicCube[row][col];
                    rubicCube[row][col] = counter;
                    Console.WriteLine($"Swap ({row}, {col}) with ({indexRowToReplace}, {indexColToReplace})");
                }
                counter++;
            }
        }
    }

    private static void Shuffle(int moves, Queue<int> queue)
    {
        for (int j = 0; j < moves % queue.Count; j++)
        {
            int toGoLast = queue.Dequeue();
            queue.Enqueue(toGoLast);
        }
    }
}
