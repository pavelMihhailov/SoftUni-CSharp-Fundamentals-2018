using System;
using System.Collections.Generic;
using System.Text;

public class Pokemon
{
    private string name;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    private string type;

    public string Type
    {
        get { return type; }
        set { type = value; }
    }

    public Pokemon(string name, string type)
    {
        this.name = name;
        this.type = type;
    }
}