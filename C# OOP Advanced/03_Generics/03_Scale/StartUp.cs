using System;

public class StartUp
{
    static void Main()
    {
        var scale = new Scale<int>(5, 5);
        Console.WriteLine(scale.GetHeavier());
    }
}
