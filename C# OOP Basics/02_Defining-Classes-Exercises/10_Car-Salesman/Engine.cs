using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Schema;

public class Engine
{
    private string model;

    private int power;

    private string displacement;

    private string efficiency;

    public Engine(string model, int power)
    {
        this.model = model;
        this.power = power;
        this.displacement = "n/a";
        this.efficiency = "n/a";
    }

    public string Model
    {
        get => this.model;
        set => this.model = value;
    }

    public int Power
    {
        get => this.power;
        set => this.power = value;
    }

    public string Displacement
    {
        get => this.displacement;
        set => this.displacement = value;
    }

    public string Efficiency
    {
        get => this.efficiency;
        set => this.efficiency = value;
    }
}
