public class Rectangle : Shape
{
    public Rectangle(double height, double width)
    {
        Height = height;
        Width = width;
    }

    public double Height { get; set; }

    public double Width { get; set; }

    public override double CalculatePerimeter()
    {
        double perimeter = 2 * (Height + Width);
        return perimeter;
    }

    public override double CalculateArea()
    {
        double area = Height * Width;
        return area;
    }

    public override string Draw()
    {
        return base.Draw() + GetType().Name;
    }
}
