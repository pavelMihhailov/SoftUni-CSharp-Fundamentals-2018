using System;

public class Circle : Shape
{
    public Circle(double radius)
    {
        Radius = radius;
    }

    public double Radius { get; set; }

    public override double CalculatePerimeter()
    {
        double perimeter = 2 * (Math.PI * Radius);
        return perimeter;
    }

    public override double CalculateArea()
    {
        double area = Math.PI * Math.Pow(Radius, 2);
        return area;
    }

    public override string Draw()
    {
        return base.Draw() + GetType().Name;
    }
}
