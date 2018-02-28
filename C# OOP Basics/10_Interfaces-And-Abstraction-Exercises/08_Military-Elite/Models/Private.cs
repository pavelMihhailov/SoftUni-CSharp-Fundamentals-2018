public class Private : Soldier, IPrivate
{
    public Private(string id, string firstName, string lastName, decimal salary) : base(id, firstName, lastName)
    {
        Salary = salary;
    }

    public decimal Salary { get; }

    public override string ToString()
    {
        return $"  Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:f2}";
    }
}
