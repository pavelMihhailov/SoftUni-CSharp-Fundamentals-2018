using System;
using System.Collections.Generic;
using System.Text;

public class Rectangle : DrawingTool
{
    public Rectangle(int firstSide, int secondSide) : base(firstSide)
    {
        this.secondSide = secondSide;
    }
}
