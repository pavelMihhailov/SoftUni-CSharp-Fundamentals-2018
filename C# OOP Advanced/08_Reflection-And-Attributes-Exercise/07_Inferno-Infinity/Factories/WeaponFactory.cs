using System;
using System.Collections.Generic;
using System.Linq;

public class WeaponFactory
{
    public Weapon CreateWeapon(List<string> args)
    {
        var rarityType = args[0].Split().ToList();
        string rarity = rarityType[0];
        string type = rarityType[1];
        string weaponName = args[1];

        int increaseDamageBy = 0;

        Rarity enumRarity = (Rarity) Enum.Parse(typeof(Rarity), rarity);
        
        switch (enumRarity)
        {
            case Rarity.Common:
                increaseDamageBy = 1;
                break;
            case Rarity.Uncommon:
                increaseDamageBy = 2;
                break;
            case Rarity.Rare:
                increaseDamageBy = 3;
                break;
            case Rarity.Epic:
                increaseDamageBy = 5;
                break;
        }
        Weapon weapon = null;

        switch (type)
        {
            case "Axe":
                weapon = new Axe(weaponName);
                break;
            case "Sword":
                weapon = new Sword(weaponName);
                break;
            case "Knife":
                weapon = new Knife(weaponName);
                break;
        }
        weapon?.IncreaseDmgByRarity(increaseDamageBy);

        return weapon;
    }
}
