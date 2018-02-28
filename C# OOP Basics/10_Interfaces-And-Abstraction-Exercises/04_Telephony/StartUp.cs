using System;

public class StartUp
{
    public static void Main()
    {
        string phones = Console.ReadLine();
        string sites = Console.ReadLine();

        Smartphone smartphone = new Smartphone();
        smartphone.ReadAndAddPhones(phones);
        smartphone.ReadAndAddSites(sites);

        Console.WriteLine(smartphone.ToString());
    }
}
