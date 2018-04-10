using System;

public class Database
{
    private int[] _integers;

    public Database(params int[] integers)
    {
        if (integers.Length > 16) throw new InvalidOperationException("Integers should be 16.");

        _integers = new int[integers.Length];
        _integers = integers;
    }

    public void AddElement(int element)
    {
        if (_integers.Length == 16) throw new InvalidOperationException("Database is full, cannot add element.");
        int[] newInts = new int[_integers.Length + 1];

        for (int i = 0; i <= _integers.Length; i++)
        {
            if (i == _integers.Length) newInts[i] = element;
            else newInts[i] = _integers[i];
        }
        _integers = newInts;
    }

    public void RemoveLastElement()
    {
        if (_integers.Length == 0) throw new InvalidOperationException("Empty database.");

        var lenghtOfIntegers = _integers.Length;
        var newInts = new int[lenghtOfIntegers - 1];

        for (int i = 0; i < _integers.Length - 1; i++)
        {
            newInts[i] = _integers[i];
        }
        _integers = newInts;
    }

    public int[] Fetch()
    {
        return _integers;
    }

    public int GetLenghtOfArray()
    {
        return _integers.Length;
    }
}
