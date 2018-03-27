using System;
using System.Collections;
using System.Collections.Generic;

public class ListyIterator<T> : IEnumerable<T>
{
    public ListyIterator(IEnumerable<T> collection)
    {
        this.collection = new List<T>(collection);
        currIndex = 0;
    }

    private List<T> collection;
    private int currIndex;

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < collection.Count; i++)
        {
            yield return collection[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public bool Move()
    {
        if (!this.HasNext()) return false;
        this.currIndex++;
        return true;
    }

    public void Print()
    {
        if (collection.Count == 0) throw new InvalidOperationException($"Invalid Operation!");
        Console.WriteLine(collection[currIndex]);
    }

    public bool HasNext()
    {
        return currIndex < collection.Count - 1;
    }

    public void PrintAll()
    {
        Console.WriteLine(string.Join(" ", collection));
    }
}
