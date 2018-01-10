using System;

public class StartUp
{
    public static void Main()
    {
        long number = long.Parse(Console.ReadLine());
        
        long[][] triangle = new long[number][];
        long currWidth = 1;

        for (long height = 0; height < number; height++)
        {
            triangle[height] = new long[currWidth];

            triangle[height][0] = 1;
            triangle[height][currWidth - 1] = 1;

            if (height >= 2)
            {
                for (long colIndex = 1; colIndex <= currWidth - 2; colIndex++)
                {
                    triangle[height][colIndex] = triangle[height - 1][colIndex - 1] + triangle[height - 1][colIndex];
                }
            }
            currWidth++;
        }
        foreach (var row in triangle)
        {
            Console.WriteLine(string.Join(" ", row));
        }
    }
}
