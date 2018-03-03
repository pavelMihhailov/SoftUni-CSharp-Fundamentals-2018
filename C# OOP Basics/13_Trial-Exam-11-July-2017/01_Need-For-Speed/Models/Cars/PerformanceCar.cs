using System.Collections.Generic;
using System.Text;

public class PerformanceCar : Car
{
    public PerformanceCar(string brand, string model, int productionYear, int horsePower, int acceleration, int suspension, int durability,
        List<string> addOns) 
        : base(brand, model, productionYear, horsePower, acceleration, suspension, durability)
    {
        AddOns = addOns;
        HorsePower = horsePower + horsePower * 50 / 100;
        Suspension = suspension - suspension * 25 / 100;
    }

    public List<string> AddOns { get; set; }

    public override void Tune(int tuneIndex, string addOn)
    {
        base.Tune(tuneIndex, addOn);
        AddOns.Add(addOn);
    }

    public override string ToString()
    {
        bool emptyAddOns = AddOns.Count == 0;

        StringBuilder str = new StringBuilder();
        str.AppendLine(base.ToString());
        str.Append("Add-ons: ");
        str.AppendLine(emptyAddOns ? $"None" : string.Join(", ", AddOns));

        return str.ToString().TrimEnd();
    }
}
