using System;
using System.Collections.Generic;
using System.Linq;

//Remove IComparable for Problems 01-04.
public class Box<T> where T : IComparable
{
    public Box(T value)
    {
        _value = value;
    }

    public Box()
    {
        list = new List<T>();
    }

    private readonly List<T> list;

    private T _value;

    public void Swap(int index1, int index2)
    {
        var oldIndex = list[index1];

        list[index1] = list[index2];
        list[index2] = oldIndex;
    }

    public void Add(T item)
    {
        list.Add(item);
    }

    public int EqualsCount(T element)
    {
        return list.Count(t => t.CompareTo(element) > 0);
    }

    //For Problem 01-02
    //public override string ToString()
    //{
    //    return $"{_value.GetType().FullName}: {_value}";
    //}

    //For Problem 03. =>
    //public override string ToString()
    //{
    //    StringBuilder sb = new StringBuilder();
    //    foreach (var item in list)
    //    {
    //        sb.AppendLine($"{item.GetType().FullName}: {item}");
    //    }
    //    return sb.ToString().TrimEnd();
    //}
}
