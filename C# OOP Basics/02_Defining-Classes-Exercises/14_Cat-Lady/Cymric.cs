using System;
using System.Collections.Generic;
using System.Text;

public class Cymric : Cat
{
    private double furSize;
    
    public double FurSize
    {
        get => this.furSize;
        set => this.furSize = value;
    }

    public override string ToString()
    {
        return $"Cymric {this.Name} {this.FurSize:f2}";
    }
}
