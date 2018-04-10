using System;

public class MathInt : IMathAbs, IMathFloor
{
    public double MathAbs(double value)
    {
        var result = Math.Abs(value);
        return result;
    }

    public double MathFloor(double value)
    {
        var result = Math.Floor(value);
        return result;
    }
}
