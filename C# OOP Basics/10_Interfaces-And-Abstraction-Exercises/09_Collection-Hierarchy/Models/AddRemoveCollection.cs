using System.Collections.Generic;

public class AddRemoveCollection : IAddRemoveCollection
{
    public AddRemoveCollection()
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
        string item = Items[Items.Count - 1];
        Items.RemoveAt(Items.Count - 1);
        return item;
    }

    public List<string> Items { get; set; }
}
