using System;
using System.Collections.Generic;
using System.Text;

public class StreetExtraordinaire : Cat
{
    private int dbsMeows;
    
    public int DbsMeows
    {
        get => this.dbsMeows;
        set => this.dbsMeows = value;
    }

    public override string ToString()
    {
        return $"StreetExtraordinaire {this.Name} {this.DbsMeows}";
    }
}