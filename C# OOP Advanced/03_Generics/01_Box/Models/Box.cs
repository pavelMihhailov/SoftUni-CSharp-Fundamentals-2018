using System.Collections.Generic;
using System.Linq;

public class Box<T> : List<T>
{
    public Box()
    {
        items = new List<T>();
    }

    private List<T> items;

    public int Count => items.Count;

    public void Add(T element)
    {
        items.Add(element);
    }

    public T Remove()
    {
        var element = items.Last();
        items.RemoveAt(items.Count - 1);

        return element;
    }
}
