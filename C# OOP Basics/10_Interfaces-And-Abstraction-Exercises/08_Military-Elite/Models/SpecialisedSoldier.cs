using System.Text;

public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
{
    protected SpecialisedSoldier(string id, string firstName, string lastName, decimal salary, string corps) : base(id, firstName, lastName, salary)
    {
        Corps = corps;
    }

    public string Corps { get; }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();

        result.AppendLine($"{base.ToString()}")
            .AppendLine($"{nameof(Corps)}: {Corps}");

        return result.ToString().Trim();
    }
}