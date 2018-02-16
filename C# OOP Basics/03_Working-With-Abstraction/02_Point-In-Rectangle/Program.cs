using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] line = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int points = int.Parse(Console.ReadLine());

        for (int i = 0; i < points; i++)
        {
            int[] point = Console.ReadLine().Split().Select(int.Parse).ToArray();
            if (PointInRectangle(line, point)) Console.WriteLine("True");
            else Console.WriteLine("False");
        }
    }

    static bool PointInRectangle(int[] recPoints, int[] point)
    {
        int x1 = recPoints[0];
        int y1 = recPoints[1];
        int x2 = recPoints[2];
        int y2 = recPoints[3];

        int xPoint = point[0];
        int yPoint = point[1];

        if (xPoint >= x1 && xPoint <= x2 && yPoint >= y1 && yPoint <= y2) return true;
        return false;
    }
}
