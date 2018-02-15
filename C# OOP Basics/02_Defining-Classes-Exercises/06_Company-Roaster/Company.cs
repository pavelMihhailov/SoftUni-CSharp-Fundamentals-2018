using System;
using System.Collections.Generic;
using System.Linq;

public class Company
{
    private List<Employee> listOfEmployee = new List<Employee>();

    public List<Employee> ListOfEmployees
    {
        get => this.listOfEmployee;
        set => this.listOfEmployee = value;
    }

    public void AddEmployee(Employee employee)
    {
        listOfEmployee.Add(employee);
    }

    public IGrouping<string, Employee> GetDepartmentWithHighestSalary()
    {
        string highestDepartment = this.listOfEmployee.GroupBy(x => x.Department, c => c.Salary)
            .OrderByDescending(x => x.Average()).First().Key;
        IGrouping<string, Employee> resultGrouping =
            listOfEmployee.GroupBy(x => x.Department).Where(x => x.Key == highestDepartment).ToList()[0];

        return resultGrouping;
    }
}
