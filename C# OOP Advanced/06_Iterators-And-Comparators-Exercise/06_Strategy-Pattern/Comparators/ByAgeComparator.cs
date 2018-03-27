using System.Collections.Generic;

public class ByAgeComparator : IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        var result = x.Age.CompareTo(y.Age);
        return result;
    }
}