using System;
using System.Collections.Generic;
using System.Text;

public class Siamese : Cat
{
    private int earSize;
    
    public int EarSize
    {
        get => this.earSize;
        set => this.earSize = value;
    }

    public override string ToString()
    {
        return $"Siamese {this.Name} {this.EarSize}";
    }
}