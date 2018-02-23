using System;

public class Person
{
    private string name;

    public string Name
    {
        get => this.name;
        internal set
        {
            if (value.Length < 3)
                throw new ArgumentException("Name's length should not be less than 3 symbols!");
            this.name = value;
        }
    }

    private int age;

    public virtual int Age
    {
        get => this.age;
        internal set
        {
            if (value < 0) throw new ArgumentException("Age must be positive!");
            this.age = value;
        }
    }

    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public override string ToString()
    {
        return $"Name: {this.Name}, Age: {this.Age}";
    }
}