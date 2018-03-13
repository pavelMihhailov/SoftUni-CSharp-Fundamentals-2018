using System.Collections.Generic;
using System.Linq;
using System.Text;

public class NationsBuilder
{
    private Dictionary<string, Nation> nations;
    private List<string> wars;

    public NationsBuilder()
    {
        nations = new Dictionary<string, Nation>
        {
            ["Air"] = new Nation(),
            ["Water"] = new Nation(),
            ["Fire"] = new Nation(),
            ["Earth"] = new Nation()
        };

        wars = new List<string>();
    }

    public void AssignBender(List<string> benderArgs)
    {
        Bender bender = BenderFactory.CreateBender(benderArgs);
        nations[benderArgs[1]].AddBender(bender);
    }

    public void AssignMonument(List<string> monumentArgs)
    {
        Monument monument = MonumentFactory.CreateMonument(monumentArgs);
        nations[monumentArgs[1]].AddMonument(monument);
    }

    public string GetStatus(string nationsType)
    {
        var str = new StringBuilder();
        str.AppendLine($"{nationsType} Nation");
        str.Append(nations[nationsType]);

        return str.ToString();
    }

    public void IssueWar(string nationsType)
    {
        wars.Add($"War {wars.Count + 1} issued by {nationsType}");

        var winnerPower = nations.Max(x => x.Value.TotalPower());
        foreach (var nation in nations.Values)
        {
            if (nation.TotalPower() != winnerPower)
            {
                nation.Clear();
            }
        }
    }
    public string GetWarsRecord()
    {
        return string.Join("\n", wars);
    }

}
