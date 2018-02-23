using System;

public class Worker : Human
{
    private decimal weekSalary;
    private decimal workHoursPerDay;

    public Worker(string firstName, string lastName, decimal weekSalary, decimal workHoursPerDay) : base(firstName, lastName)
    {
        WeekSalary = weekSalary;
        WorkHoursPerDay = workHoursPerDay;
    }

    public decimal WeekSalary
    {
        get => this.weekSalary;
        set
        {
            if (value <= 10) throw new ArgumentException($"Expected value mismatch! Argument: weekSalary");
            this.weekSalary = value;
        }
    }

    public decimal WorkHoursPerDay
    {
        get => this.workHoursPerDay;
        set
        {
            if (value < 1 || value > 12) throw new ArgumentException($"Expected value mismatch! Argument: workHoursPerDay");
            this.workHoursPerDay = value;
        }
    }

    public decimal SalaryPerHour()
    {
        return this.weekSalary / (this.workHoursPerDay * 5);
    }

    public override string ToString()
    {
        return
            $"{base.ToString()}\nWeek Salary: {WeekSalary:f2}\nHours per day: {WorkHoursPerDay:f2}\nSalary per hour: {SalaryPerHour():f2}";
    }
}
