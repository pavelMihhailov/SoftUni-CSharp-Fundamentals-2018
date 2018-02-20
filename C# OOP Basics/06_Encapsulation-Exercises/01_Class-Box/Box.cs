using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

public class Box
{
    private double length;
    private double width;
    private double height;

    public double Length
    {
        get => this.length;
        set => this.length = value;
    }

    public double Width
    {
        get => this.width;
        set => this.width = value;
    }

    public double Height
    {
        get => this.height;
        set => this.height = value;
    }

    public Box(double length, double width, double height)
    {
        this.length = length;
        this.width = width;
        this.height = height;
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
}