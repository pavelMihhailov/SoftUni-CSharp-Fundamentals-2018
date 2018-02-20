using System;

public class Dough
{
    private string flourType;

    public string FlourType
    {
        get { return flourType; }
        set
        {
            if (value.ToLower() == "white" || value.ToLower() == "wholegrain") this.flourType = value;
            else throw new ArgumentException("Invalid type of dough.");
        }
    }

    private string bakingTechnique;

    public string BakingTechnique
    {
        get { return bakingTechnique; }
        set
        {
            string input = value.ToLower();
            if (input == "crispy" || input == "chewy" || input == "homemade")
            {
                this.bakingTechnique = value;
            }
            else throw new ArgumentException("Invalid type of dough.");
        }
    }

    private double weight;

    public double Weight
    {
        get { return weight; }
        set
        {
            if (value >= 1 && value <= 200) this.weight = value;
            else throw new ArgumentException("Dough weight should be in the range [1..200].");
        }
    }

    public Dough(string flourType, string bakingTechnique, double weight)
    {
        FlourType = flourType;
        BakingTechnique = bakingTechnique;
        Weight = weight;
    }

    public double TotalCalories()
    {
        double flourMod = 0;
        double bakingMod = 0;
        switch (BakingTechnique.ToLower())
        {
            case "crispy": bakingMod = 0.9;
                break;
            case "chewy": bakingMod = 1.1;
                break;
            case "homemade": bakingMod = 1.0;
                break;
        }
        switch (FlourType.ToLower())
        {
            case "white": flourMod = 1.5;
                break;
            case "wholegrain": flourMod = 1.0;
                break;
        }
        return 2 * Weight * flourMod * bakingMod;
    }
}
