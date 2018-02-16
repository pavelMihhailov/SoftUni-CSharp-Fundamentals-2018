using System;
using System.Collections.Generic;
using System.Text;

public class StudentSystem
{
    private Dictionary<string, Student> studentsInfo;

    public StudentSystem()
    {
        this.StudentsInfo = new Dictionary<string, Student>();
    }

    public Dictionary<string, Student> StudentsInfo
    {
        get { return studentsInfo; }
        private set { studentsInfo = value; }
    }

    public void ParseCommand()
    {
        string[] args = Console.ReadLine().Split();

        if (args[0] == "Create")
        {
            CreateStudent(args);
        }
        else if (args[0] == "Show")
        {
            ShowStudentInfo(args);
        }
        else if (args[0] == "Exit")
        {
            Environment.Exit(0);
        }
    }

    private void ShowStudentInfo(string[] args)
    {
        var name = args[1];
        if (StudentsInfo.ContainsKey(name))
        {
            var student = StudentsInfo[name];
            string view = $"{student.Name} is {student.Age} years old.";

            if (student.Grade >= 5.00)
            {
                view += " Excellent student.";
            }
            else if (student.Grade < 5.00 && student.Grade >= 3.50)
            {
                view += " Average student.";
            }
            else
            {
                view += " Very nice person.";
            }
            Console.WriteLine(view);
        }
    }

    private void CreateStudent(string[] args)
    {
        var name = args[1];
        var age = int.Parse(args[2]);
        var grade = double.Parse(args[3]);
        if (!studentsInfo.ContainsKey(name))
        {
            var student = new Student(name, age, grade);
            StudentsInfo[name] = student;
        }
    }
}