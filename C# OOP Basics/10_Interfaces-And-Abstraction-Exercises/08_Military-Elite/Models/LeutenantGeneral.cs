using System.Collections.Generic;
using System.Text;

public class LeutenantGeneral : Private, ILeutenantGeneral
{
    public LeutenantGeneral(string id, string firstName, string lastName, decimal salary, IList<IPrivate> privates) : base(id, firstName, lastName, salary)
    {
        Privates = privates;
    }

    public IList<IPrivate> Privates { get; }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        result.AppendLine($"{base.ToString()}")
            .AppendLine($"{nameof(Privates)}:");

        foreach (var @private in Privates)
        {
            result.AppendLine($"  {@private}");
        }
        return result.ToString().Trim();
    }
}
