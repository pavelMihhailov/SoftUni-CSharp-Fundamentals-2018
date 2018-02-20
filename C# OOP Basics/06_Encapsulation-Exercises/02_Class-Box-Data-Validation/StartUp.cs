using System;

public class StartUp
{
    public static void Main()
    {
        double length = double.Parse(Console.ReadLine());
        double width = double.Parse(Console.ReadLine());
        double height = double.Parse(Console.ReadLine());

        try
        {
            Box newBox = new Box(length, width, height);
            Console.WriteLine(newBox.ToString());
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
