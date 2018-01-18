using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    public static void Main()
    {
        int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
        List<List<long>> matrix = new List<List<long>>();
        int n = 1;

        for (int rowIndex = 0; rowIndex < dimensions[0]; rowIndex++)
        {
            matrix.Add(new List<long>());
            for (int colIndex = 0; colIndex < dimensions[1]; colIndex++)
            {
                matrix[rowIndex].Add(n);
                n++;
            }
        }

        string command = Console.ReadLine();
        while (true)
        {
            if (command == "Nuke it from orbit") break;

            int[] coordinates = command.Split().Select(int.Parse).ToArray();
            int boomRow = coordinates[0];
            int boomCol = coordinates[1];
            int boomRadius = coordinates[2];

            //center
            if (boomRow >= 0 && boomRow < matrix.Count && boomCol >= 0 && boomCol < matrix[boomRow].Count)
            {
                matrix[boomRow][boomCol] = 0;
            }
            //leftside
            for (int cnt = 1; cnt <= boomRadius; cnt++)
            {
                if (boomCol - cnt < 0) continue;
                else matrix[boomRow][boomCol - cnt] = 0;
            }

            //rightside
            for (int cnt = 1; cnt <= boomRadius; cnt++)
            {
                if (boomCol + cnt > matrix[boomRow].Count - 1) continue;
                else matrix[boomRow][boomCol + cnt] = 0;
            }
            //upside
            for (int cnt = 1; cnt <= boomRadius; cnt++)
            {
                if (boomRow - cnt < 0) break;
                if (boomRow > matrix.Count - 1) continue;
                else matrix[boomRow - cnt][boomCol] = 0;
            }
            
            //downside
            for (int cnt = 1; cnt <= boomRadius; cnt++)
            {
                if (boomRow + cnt > matrix.Count - 1) break;
                if (boomRow < 0) continue;
                else matrix[boomRow + cnt][boomCol] = 0;
            }
            for (int i = 0; i < matrix.Count; i++)
            {
                for (int j = matrix[i].Count - 1; j >= 0; j--)
                {
                    if (matrix[i][j] == 0) matrix[i].RemoveAt(j);
                }
            }

            command = Console.ReadLine();
        }
        for (int i = 0; i < matrix.Count; i++)
        {
            for (int j = matrix[i].Count - 1; j >= 0; j--)
            {
                if (matrix[i][j] == 0) matrix[i].RemoveAt(j);
            }
        }
        foreach (var row in matrix)
        {
            Console.WriteLine(string.Join(" ", row));
        }
    }
}
