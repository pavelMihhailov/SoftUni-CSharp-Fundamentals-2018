using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        int maxCapacity = int.Parse(Console.ReadLine());

        Queue<string> bunkers = new Queue<string>();
        Queue<int> weapons = new Queue<int>();

        var leftCapacity = maxCapacity;

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "Bunker Revision") break;

            string[] tokens = input.Split();

            foreach (var element in tokens)
            {
                int weapon;
                bool isDigit = int.TryParse(element, out weapon);

                if (!isDigit) bunkers.Enqueue(element);

                else
                {
                    leftCapacity = AddWeaponIfCanAndPrint(maxCapacity, bunkers, weapons, leftCapacity, weapon);
                }
            }
        }
    }

    private static int AddWeaponIfCanAndPrint(int maxCapacity, Queue<string> bunkers, Queue<int> weapons, int leftCapacity, int weapon)
    {
        bool fit = false;

        while (bunkers.Count > 1)
        {
            if (leftCapacity >= weapon)
            {
                weapons.Enqueue(weapon);
                leftCapacity -= weapon;
                fit = true;
                break;
            }

            if (weapons.Count == 0) Console.WriteLine($"{bunkers.Dequeue()} -> Empty");
            else Console.WriteLine($"{bunkers.Dequeue()} -> {string.Join(", ", weapons)}");

            weapons.Clear();
            leftCapacity = maxCapacity;
        }

        if (!fit)
        {
            if (weapon <= maxCapacity)
            {
                while (leftCapacity < weapon)
                {
                    leftCapacity += weapons.Dequeue();
                }
                weapons.Enqueue(weapon);
                leftCapacity -= weapon;
            }
        }
        return leftCapacity;
    }
}