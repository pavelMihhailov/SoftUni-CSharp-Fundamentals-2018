using System.Collections.Generic;

public class MyList : IMyList
{
    public MyList()
    {
        Items = new List<string>();
    }

    public int Add(string item)
    {
        Items.Insert(0, item);
        return 0;
    }

    public string Remove()
    {
        string item = Items[0];
        Items.RemoveAt(0);
        return item;
    }

    public int Used()
    {
        return Items.Count;
    }

    public List<string> Items { get; set; }
}
