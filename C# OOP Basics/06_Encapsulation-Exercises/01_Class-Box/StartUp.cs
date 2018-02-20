using System;

public class StartUp
{
    public static void Main()
    {
        double length = double.Parse(Console.ReadLine());
        double width = double.Parse(Console.ReadLine());
        double height = double.Parse(Console.ReadLine());
        
        Box newBox = new Box(length, width, height);
        Console.WriteLine($"Surface Area - {newBox.SurfaceArea():f2}");
        Console.WriteLine($"Lateral Surface Area - {newBox.LateralSurfArea():f2}");
        Console.WriteLine($"Volume - {newBox.Volume():f2}");
    }
}
