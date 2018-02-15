using System;
using System.Collections.Generic;
using System.Text;

public class Cargo
{
    private int weight;
    private string type;

    public Cargo(int weight, string type)
    {
        this.weight = weight;
        this.type = type;
    }

    public int Weight
    {
        get => this.weight;
        set => this.weight = value;
    }

    public string Type
    {
        get => this.type;
        set => this.type = value;
    }
}
