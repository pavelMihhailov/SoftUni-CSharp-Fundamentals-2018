using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class Company
{
    private string name;

    private string department;

    private decimal salary;

    public Company(string name, string department, decimal salary)
    {
        this.name = name;
        this.department = department;
        this.salary = salary;
    }

    public string Name
    {
        get => this.name;
        set => this.name = value;
    }

    public string Department
    {
        get => this.department;
        set => this.department = value;
    }

    public decimal Salary
    {
        get => this.salary;
        set => this.salary = value;
    }
}
