using System;

public class Program
{
    public static void Main()
    {
        var input = Console.ReadLine();
        DrawingTool figure = null;

        if (input == "Square")
        {
            int size = int.Parse(Console.ReadLine());
            figure = new Square(size);
        }
        else
        {
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            figure = new Rectangle(width, height);
        }
        figure.Draw();
    }
}
