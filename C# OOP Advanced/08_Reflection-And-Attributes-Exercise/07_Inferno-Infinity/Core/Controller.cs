using System;
using System.Collections.Generic;
using System.Linq;

public class Controller
{
    public Controller()
    {
        weapons = new List<Weapon>();
    }

    private List<Weapon> weapons;

    public void ExecuteCommands(List<string> args)
    {
        string command = args[0];

        string weaponName = args[1];
        int socketIndex;
        switch (command)
        {
            case "Create":
                var weaponFactory = new WeaponFactory();
                weapons.Add(weaponFactory.CreateWeapon(args.Skip(1).ToList()));
                break;
            case "Add":
                socketIndex = int.Parse(args[2]);
                string gemInfo = args[3];
                AddGemToWeapon(weaponName, socketIndex, gemInfo);
                break;
            case "Remove":
                socketIndex = int.Parse(args[2]);
                RemoveGemFromWeapon(weaponName, socketIndex);
                break;
            case "Print":
                weapons.First(x => x.Name.Equals(weaponName)).IncreaseDmgByGems();
                Console.WriteLine(weapons.First(x => x.Name.Equals(weaponName)).ToString());
                break;
        }
    }

    public void AddGemToWeapon(string weaponName, int socketIndex, string gemInfo)
    {
        GemFactory gemFactory = new GemFactory();
        IGem newGem = gemFactory.CreateGem(gemInfo);
        weapons.First(x => x.Name.Equals(weaponName)).SocketWithGems.Insert(socketIndex, newGem);
    }

    public void RemoveGemFromWeapon(string weaponName, int socketIndex)
    {
        weapons.First(x => x.Name.Equals(weaponName)).SocketWithGems.RemoveAt(socketIndex);
    }
}
