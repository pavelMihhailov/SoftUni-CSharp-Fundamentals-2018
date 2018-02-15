using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        Company company = new Company();

        for (int i = 0; i < n; i++)
        {
            string[] line = Console.ReadLine().Split(' ');
            string name = line[0];
            decimal salary = decimal.Parse(line[1]);
            string position = line[2];
            string department = line[3];
            string email = "n/a";
            int age = -1;

            if (line.Length == 6)
            {
                email = line[4];
                age = int.Parse(line.Last());
            }
            else if (line.Length == 5)
            {
                int currAge = 0;
                bool isAge = int.TryParse(line[4], out currAge);

                if (isAge) age = currAge;
                else email = line[4];
            }

            Employee newEmployee = new Employee
            {
                Age = age,
                Department = department,
                Email = email,
                Name = name,
                Position = position,
                Salary = salary
            };

            company.AddEmployee(newEmployee);
        }
        IGrouping<string, Employee> result = company.GetDepartmentWithHighestSalary();

        Console.WriteLine($"Highest Average Salary: {result.Key}");

        foreach (var each in result.OrderByDescending(x => x.Salary))
        {
            Console.WriteLine($"{each.Name} {each.Salary:f2} {each.Email} {each.Age}");
        }
    }
}
