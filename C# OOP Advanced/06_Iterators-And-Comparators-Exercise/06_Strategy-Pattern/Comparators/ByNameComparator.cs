using System.Collections.Generic;

public class ByNameComparator : IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        var result = x.Name.Length.CompareTo(y.Name.Length);
        if (result == 0) result = x.Name[0].ToString().ToLower().CompareTo(y.Name[0].ToString().ToLower());
        return result;
    }
}
