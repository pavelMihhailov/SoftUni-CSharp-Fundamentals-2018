using System.Collections.Generic;

public class Axe : Weapon
{
    public Axe(string name) : base(name)
    {
        MinDamage = 5;
        MaxDamage = 10;
        SocketWithGems = new List<IGem>(4);
    }
}