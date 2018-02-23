using System;
using System.Linq;

public class Student : Human
{
    private string facultyNum;

    public string FacultyNum
    {
        get => this.facultyNum;
        set
        {
            if (value.Length < 5 || value.Length > 10 || !value.All(char.IsLetterOrDigit)) throw new ArgumentException("Invalid faculty number!");
            this.facultyNum = value;
        }
    }

    public Student(string firstName, string lastName, string facultyNum) : base(firstName, lastName)
    {
        FacultyNum = facultyNum;
    }

    public override string ToString()
    {
        return $"{base.ToString()}\nFaculty number: {FacultyNum}\n";
    }
}
