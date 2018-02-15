using System;
using System.Collections.Generic;
using System.Text;

public class Rectangle
{
    private string id;

    private double width;

    private double height;

    private double[] coordinates;

    public Rectangle(string id, double width, double height, double[] coordinates)
    {
        this.id = id;
        this.width = width;
        this.height = height;
        this.coordinates = coordinates;
    }

    public string ID
    {
        get => this.id;
        set => this.id = value;
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

    public bool Intersect(Rectangle rectangle)
    {
        if (this.coordinates[0] + this.Width < rectangle.coordinates[0]
            || rectangle.coordinates[0] + rectangle.Width < this.coordinates[0]
            || this.coordinates[1] + this.Height < rectangle.coordinates[1]
            || rectangle.coordinates[1] + rectangle.Height < this.coordinates[1]) return false;
        return true;
    }

}
