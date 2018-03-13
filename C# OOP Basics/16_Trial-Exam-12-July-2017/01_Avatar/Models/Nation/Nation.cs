using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Nation
{
    private List<Bender> benders;
    private List<Monument> monuments;

    public Nation()
    {
        benders = new List<Bender>();
        monuments = new List<Monument>();
    }

    public void AddBender(Bender bender)
    {
        benders.Add(bender);
    }

    public void AddMonument(Monument monument)
    {
        monuments.Add(monument);
    }

    public double TotalPower()
    {
        double totalPower = 0;

        totalPower += benders.Sum(x => x.TotalPower());
        int percent = monuments.Sum(x => x.AffinityType());
        totalPower += totalPower / 100 * percent;

        return totalPower;
    }

    public void Clear()
    {
        benders.Clear();
        monuments.Clear();
    }

    public override string ToString()
    {
        StringBuilder str = new StringBuilder();

        str.Append("Benders:");
        if (benders.Count == 0) str.Append(" None");
        else benders.ForEach(x => str.Append(Environment.NewLine + $"###{x.ToString()}"));
        str.AppendLine();

        str.Append("Monuments:");
        if (monuments.Count == 0) str.Append(" None");
        else monuments.ForEach(x => str.Append(Environment.NewLine + $"###{x.ToString()}"));

        return str.ToString();
    }
}
