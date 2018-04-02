using System.Collections.Generic;

public class Knife : Weapon
{
    public Knife(string name) : base(name)
    {
        MinDamage = 3;
        MaxDamage = 4;
        SocketWithGems = new List<IGem>(2);
    }
}
