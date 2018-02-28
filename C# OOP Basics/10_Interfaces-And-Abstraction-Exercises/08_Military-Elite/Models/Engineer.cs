using System.Collections.Generic;
using System.Text;

public class Engineer : SpecialisedSoldier, IEngineer
{
    public Engineer(string id, string firstName, string lastName, decimal salary, string corps, IList<IRepair> repairs) : base(id, firstName, lastName, salary, corps)
    {
        Repairs = repairs;
    }

    public IList<IRepair> Repairs { get; }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();

        result.AppendLine($"{base.ToString()}")
            .AppendLine($"{nameof(Repairs)}:");
        foreach (var repair in Repairs)
        {
            result.AppendLine(" " + repair);
        }

        return result.ToString().Trim();
    }
}
