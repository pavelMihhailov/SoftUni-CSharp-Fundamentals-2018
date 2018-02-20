using System;
using System.Collections.Generic;
using System.Text;

public class Topping
{
    private string type;

    public string Type
    {
        get { return type; }
        set
        {
            string input = value.ToLower();
            if (input == "meat" || input == "veggies" || input == "cheese" || input == "sauce")
            {
                this.type = value;
            }
            else throw new ArgumentException($"Cannot place {value} on top of your pizza.");
        }
    }

    private double weight;

    public double Weight
    {
        get { return weight; }
        set
        {
            if (value >= 1 && value <= 50) this.weight = value;
            else
                throw new ArgumentException($"{Type} weight should be in the range [1..50].");
        }
    }

    public Topping(string type, double weight)
    {
        Type = type;
        Weight = weight;
    }

    public double TotalCalories()
    {
        double multiplier = 0;
        switch (Type.ToLower())
        {
            case "meat": multiplier = 1.2;
                break;
            case "veggies": multiplier = 0.8;
                break;
            case "cheese": multiplier = 1.1;
                break;
            case "sauce": multiplier = 0.9;
                break;
        }
        return 2 * Weight * multiplier;
    }
}