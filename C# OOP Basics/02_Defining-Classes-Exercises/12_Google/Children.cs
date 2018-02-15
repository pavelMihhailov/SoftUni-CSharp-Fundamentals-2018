using System;
using System.Collections.Generic;
using System.Text;

public class Children
{
    private string name;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    private string birthday;

    public string Birthday
    {
        get { return birthday; }
        set { birthday = value; }
    }

    public Children(string name, string birthday)
    {
        this.name = name;
        this.birthday = birthday;
    }
}
