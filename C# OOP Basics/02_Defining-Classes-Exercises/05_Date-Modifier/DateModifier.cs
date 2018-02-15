using System;

public class DateModifier
{
    public static int CalcDiff(string firstDate, string secondDate)
    {
        TimeSpan days = DateTime.Parse(firstDate) - DateTime.Parse(secondDate);
        return Math.Abs(days.Days);
    }
}