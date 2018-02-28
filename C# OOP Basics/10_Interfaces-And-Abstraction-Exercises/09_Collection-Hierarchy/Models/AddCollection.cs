using System.Collections.Generic;

public class AddCollection : IAddCollection
{
    public AddCollection()
    {
        Items = new List<string>();
    }

    public int Add(string item)
    {
        Items.Add(item);
        return Items.Count - 1;
    }

    public List<string> Items { get; set; }
}
