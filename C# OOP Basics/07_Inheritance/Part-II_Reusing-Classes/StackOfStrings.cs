using System;
using System.Collections.Generic;

public class StackOfStrings
{
    private List<string> data;

    public StackOfStrings()
    {
        this.data = new List<string>();
    }

    public void Push(string item)
    {
        data.Add(item);
    }

    public bool IsEmpty()
    {
        return this.data.Count == 0;
    }

    public string Pop()
    {
        int index = this.data.Count - 1;
        string element = data[index];
        data.RemoveAt(index);
        return element;
    }

    public string Peek()
    {
        return data[data.Count - 1];
    }
}
