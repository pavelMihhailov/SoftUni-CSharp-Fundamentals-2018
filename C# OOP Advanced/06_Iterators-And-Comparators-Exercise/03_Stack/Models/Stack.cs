using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Stack<T> : IEnumerable<T>
{
    public Stack()
    {
        this.collection = new List<T>();
    }

    private List<T> collection;

    public T Pop()
    {
        if (collection.Count == 0) throw new InvalidOperationException("No elements");
        var element = collection.Last();
        collection.RemoveAt(collection.Count - 1);
        return element;
    }

    public void Push(T element)
    {
        collection.Add(element);
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = collection.Count - 1; i >= 0; i--)
        {
            yield return collection[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
