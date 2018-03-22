using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CustomList<T> where T : IEnumerable, IComparable
{
    public CustomList()
    {
        list = new List<T>();
    }

    private IList<T> list;

    public void Add(T element)
    {
        list.Add(element);
    }

    public T Remove(int index)
    {
        T element = list[index];
        list.Remove(element);

        return element;
    }

    public bool Contains(T element)
    {
        return list.Contains(element);
    }

    public void Swap(int index1, int index2)
    {
        T oldElement = list[index1];

        list[index1] = list[index2];
        list[index2] = oldElement;
    }

    public int CountGreaterThan(T element)
    {
        return list.Count(t => element.CompareTo(t) < 0);
    }

    public T Max()
    {
        return list.Max();
    }

    public T Min()
    {
        return list.Min();
    }

    public void Sort()
    {
        list = list.OrderBy(x => x).ToList();
    }

    public void PrintAllElements()
    {
        foreach (var element in list)
        {
            Console.WriteLine(element.ToString());
        }
    }
}
