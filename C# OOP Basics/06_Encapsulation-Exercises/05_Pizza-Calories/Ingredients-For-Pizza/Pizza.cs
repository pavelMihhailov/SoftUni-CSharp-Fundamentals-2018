using System;
using System.Collections.Generic;
using System.Linq;

public class Pizza
{
    private string name;

    public string Name
    {
        get { return name; }
        set
        {
            if (value.Length > 15 || string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            this.name = value;
        }
    }

    private List<Topping> toppings;

    public List<Topping> Toppings
    {
        get { return toppings; }
        set => this.toppings = value;
    }

    private int numberOfToppings;
    
    public int NumberOfToppings
    {
        get { return numberOfToppings; }
        set
        {
            if (value > 10 || value < 0) throw new ArgumentException("Number of toppings should be in range [0..10].");
            this.numberOfToppings = value;
        }
    }


    private Dough dough;

    public Dough Dough
    {
        get { return dough; }
        set { dough = value; }
    }

    public Pizza()
    {
        Toppings = new List<Topping>();
    }

    public void AddTopping(Topping topping)
    {
        toppings.Add(topping);
    }

    public override string ToString()
    {
        return $"{Name} - {Dough.TotalCalories() + Toppings.Sum(c => c.TotalCalories()):f2} Calories.";
    }
}
