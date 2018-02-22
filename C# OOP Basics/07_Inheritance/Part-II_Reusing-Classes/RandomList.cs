using System;
using System.Collections.Generic;

public class RandomList : List<string>
{
    private Random rnd;

    public RandomList()
    {
        this.rnd = new Random();
    }

    public object RandomString()
    {
        if (this.Count == 0) return string.Empty;
        int index = rnd.Next(0, this.Count - 1);
        object element = this[index];
        this.RemoveAt(index);
        return element.ToString();
    }
}
