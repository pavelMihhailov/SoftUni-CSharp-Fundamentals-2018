using System.Collections.Generic;

public class Sword : Weapon
{
    public Sword(string name) : base(name)
    {
        MinDamage = 4;
        MaxDamage = 6;
        SocketWithGems = new List<IGem>(3);
    }
}
