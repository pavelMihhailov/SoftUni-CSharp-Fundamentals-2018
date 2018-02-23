using System;

public class Animal
{
    private string name;
    private int age;
    private string gender;

    public Animal(string name, int age, string gender)
    {
        Name = name;
        Age = age;
        Gender = gender;
    }

    public string Name
    {
        get => this.name;
        set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                throw new InvalidInputException();
            this.name = value;
        }
    }

    public int Age
    {
        get => this.age;
        set
        {
            if (value < 0 || string.IsNullOrEmpty(value.ToString())) throw new InvalidInputException();
            this.age = value;
        }
    }

    public string Gender
    {
        get => this.gender;
        set
        {
            if (!value.ToLower().Equals("male") && !value.ToLower().Equals("female"))
                throw new ArgumentException("Invalid input!");
            this.gender = value;
        }
    }

    public virtual void ProduceSound()
    {

    }
}
