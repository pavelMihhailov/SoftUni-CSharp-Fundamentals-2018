using System;

public class GraphicEditor
{
    public void DrawShape(IShape shape)
    {
        Console.WriteLine($"I`m a {shape.Type}");
    }
}
