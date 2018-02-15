using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Person
{
    private string name;
    private int age;
    
    public string Name
    {
        get => this.name;
        set => this.name = value;
    }

    public int Age
    {
        get => this.age;
        set => this.age = value;
    }

    public Person()
    {
        name = "No name";
        age = 1;
    }

    public Person(int age)
    {
        name = "No name";
        this.age = age;
    }

    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }
}
