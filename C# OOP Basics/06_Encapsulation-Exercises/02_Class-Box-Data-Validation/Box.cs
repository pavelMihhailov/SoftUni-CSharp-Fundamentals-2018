using System;

public class Box
{
    private double length;
    private double width;
    private double height;

    public Box(double length, double width, double height)
    {
        this.Length = length;
        this.Width = width;
        this.Height = height;
    }

    public double Length
    {
        get => this.length;
        set
        {
            if (value <= 0) throw new ArgumentException("Length cannot be zero or negative.");
            this.length = value;
        }
    }

    public double Width
    {
        get => this.width;
        set
        {
            if (value <= 0) throw new ArgumentException("Width cannot be zero or negative.");
            this.width = value;
        }
    }

    public double Height
    {
        get => this.height;
        set
        {
            if (value <= 0) throw new ArgumentException("Height cannot be zero or negative.");
            this.height = value;
        }
    }
    
    public double SurfaceArea()
    {
        return 2 * Length * Width + 2 * Length * Height + 2 * Width * Height;
    }

    public double LateralSurfArea()
    {
        return 2 * Length * Height + 2 * Width * Height;
    }

    public double Volume()
    {
        return Length * Width * Height;
    }

    public override string ToString()
    {
        return
            $"Surface Area - {SurfaceArea():f2}\nLateral Surface Area - {LateralSurfArea():f2}\nVolume - {Volume():f2}";
    }
}