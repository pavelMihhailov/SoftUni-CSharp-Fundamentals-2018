using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        int priceBullet = int.Parse(Console.ReadLine());
        int sizeGunBarrel = int.Parse(Console.ReadLine());
        List<int> bullets = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToList();
        List<int> locks = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToList();
        int intelligence = int.Parse(Console.ReadLine());

        int bulletForReload = 0;
        int bulletsShot = 0;

        //shoot
        for (int i = bullets.Count - 1; i >= 0; i--)
        {
            if (bullets[i] <= locks[0])
            {
                Console.WriteLine("Bang!");
                locks.RemoveAt(0);
            }
            else Console.WriteLine("Ping!");
            bullets.RemoveAt(i);
            bulletsShot++;
            bulletForReload++;
            if (bulletForReload == sizeGunBarrel && bullets.Count > 0)
            {
                Console.WriteLine("Reloading!");
                bulletForReload -= sizeGunBarrel;
            }
            if (locks.Count == 0)
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${intelligence - (priceBullet * bulletsShot)}");
                break;
            }
            if (bullets.Count == 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
                break;
            }
        }

    }
}
