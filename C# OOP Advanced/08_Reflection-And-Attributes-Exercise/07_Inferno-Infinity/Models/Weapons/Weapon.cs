using System.Collections.Generic;
using System.Linq;

public abstract class Weapon
{
    protected Weapon(string name)
    {
        Name = name;
    }

    public string Name { get; set; }

    public int MinDamage { get; set; }

    public int MaxDamage { get; set; }

    public List<IGem> SocketWithGems { get; set; }

    public void IncreaseDmgByRarity(int increaseBy)
    {
        MinDamage *= increaseBy;
        MaxDamage *= increaseBy;
    }

    public void IncreaseDmgByGems()
    {
        int addToMinDmg = SocketWithGems.Sum(x => x.Strenght) * 2 + SocketWithGems.Sum(x => x.Agility);
        int addToMaxDmg = SocketWithGems.Sum(x => x.Strenght) * 3 + SocketWithGems.Sum(x => x.Agility) * 4;

        MinDamage += addToMinDmg;
        MaxDamage += addToMaxDmg;
    }

    public override string ToString()
    {
        int sumStrenght = SocketWithGems.Sum(x => x.Strenght);
        int sumAgility = SocketWithGems.Sum(x => x.Agility);
        int sumVitality = SocketWithGems.Sum(x => x.Vitality);

        return
            $"{Name}: {MinDamage}-{MaxDamage} Damage, +{sumStrenght} Strength, +{sumAgility} Agility, +{sumVitality} Vitality";
    }
}