using System;
using System.Collections.Generic;
using System.Linq;

public class Person
{
    private string name;
    private decimal money;
    private List<Product> products;

    public string Name
    {
        get => this.name;
        set
        {
            if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value)) throw new ArgumentException("Name cannot be empty");
            this.name = value;
        }
    }

    public decimal Money
    {
        get => this.money;
        set
        {
            if (value < 0) throw new ArgumentException("Money cannot be negative");
            this.money = value;
        }
    }

    public List<Product> Products
    {
        get => this.products;
        set => this.products = value;
    }

    public Person(string name, decimal money)
    {
        this.Name = name;
        this.Money = money;
        this.Products = new List<Product>();
    }

    public override string ToString()
    {
        if (Products.Count == 0) return $"{Name} - Nothing bought";
        return $"{Name} - {string.Join(", ", Products.Select(x => x.Name))}";
    }
}
