using System;

public class Scale<T> where T : IComparable<T>
{
    private T _left;
    private T _right;

    public Scale(T left, T right)
    {
        _left = left;
        _right = right;
    }

    public T GetHeavier()
    {
        if (_left.CompareTo(_right) > 0) return _left;
        if (_left.CompareTo(_right) < 0) return _right;
        return default(T);
    }
}
