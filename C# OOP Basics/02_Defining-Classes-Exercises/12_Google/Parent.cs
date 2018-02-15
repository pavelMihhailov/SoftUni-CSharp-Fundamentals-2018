using System;
using System.Collections.Generic;
using System.Text;

public class Parent
{
    private string name;

    private string birthday;

    public Parent(string name, string birthday)
    {
        this.name = name;
        this.birthday = birthday;
    }

    public string Name
    {
        get => this.name;
        set => this.name = value;
    }

    public string Birthday
    {
        get => this.birthday;
        set => this.birthday = value;
    }
}
