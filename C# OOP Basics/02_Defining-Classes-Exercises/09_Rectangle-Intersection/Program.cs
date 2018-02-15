using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

        List<Rectangle> rectangles = new List<Rectangle>();

        for (int i = 0; i < input[0]; i++)
        {
            string[] line = Console.ReadLine().Split();
            string id = line[0];
            double width = double.Parse(line[1]);
            double height = double.Parse(line[2]);
            double[] coordinates = new[] {double.Parse(line[3]), double.Parse(line[4])};
            
            Rectangle newRectangle = new Rectangle(id, width, height, coordinates);
            rectangles.Add(newRectangle);
        }
        for (int i = 0; i < input[1]; i++)
        {
            string[] line = Console.ReadLine().Split();
            string firstId = line[0];
            string secondId = line[1];

            Rectangle firstRec = rectangles.Find(x => x.ID.Equals(firstId));
            Rectangle secondRec = rectangles.Find(x => x.ID.Equals(secondId));

            if (firstRec.Intersect(secondRec)) Console.WriteLine("true");
            else Console.WriteLine("false");
        }
    }
}
