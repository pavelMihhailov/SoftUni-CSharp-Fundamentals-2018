using System;
using System.Collections.Generic;
using System.Text;

public abstract class DrawingTool
{
    protected int firstSide;

    protected int secondSide;

    public DrawingTool(int firstSide)
    {
        this.firstSide = firstSide;
        this.secondSide = firstSide;
    }

    public void Draw()
    {
        string topAndBottomRow = "|" + new string('-', this.firstSide) + "|";

        Console.WriteLine(topAndBottomRow);
        for (int row = 0; row < this.secondSide - 2; row++)
        {
            Console.WriteLine("|" + new string(' ', this.firstSide) + "|");
        }
        Console.WriteLine(topAndBottomRow);
    }
}
