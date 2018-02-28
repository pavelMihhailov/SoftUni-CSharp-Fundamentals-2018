using System.Collections.Generic;
using System.Text;

public class Commando : SpecialisedSoldier, ICommando
{
    public Commando(string id, string firstName, string lastName, decimal salary, string corps, IList<IMission> missions) : base(id, firstName, lastName, salary, corps)
    {
        Missions = missions;
    }

    public IList<IMission> Missions { get; }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();

        result.AppendLine($"{base.ToString()}")
            .AppendLine($"{nameof(Missions)}:");

        foreach (var mission in Missions)
        {
            result.AppendLine(mission.ToString());
        }

        return result.ToString().Trim();
    }
}
