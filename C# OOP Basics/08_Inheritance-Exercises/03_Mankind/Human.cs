using System;

public class Human
{
    private string firstName;
    private string lastName;

    public Human(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public string FirstName
    {
        get => this.firstName;
        set
        {
            bool startWithCapital = Char.IsUpper(value[0]);
            bool hasMoreThan3Length = value.Length > 3;
            if (!startWithCapital) throw new ArgumentException("Expected upper case letter! Argument: firstName");
            if (!hasMoreThan3Length) throw new ArgumentException("Expected length at least 4 symbols! Argument: firstName");
            this.firstName = value;
        }
    }

    public string LastName
    {
        get => this.lastName;
        set
        {
            bool startWithCapital = Char.IsUpper(value[0]);
            bool hasMoreThan2Length = value.Length > 2;
            if (!startWithCapital) throw new ArgumentException("Expected upper case letter! Argument: lastName");
            if (!hasMoreThan2Length) throw new ArgumentException("Expected length at least 3 symbols! Argument: lastName");
            this.lastName = value;
        }
    }

    public override string ToString()
    {
        return $"First Name: {FirstName}\nLast Name: {LastName}";
    }
}
