using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        List<Cat> cats = new List<Cat>();

        while (true)
        {
            string[] line = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            if (line[0] == "End") break;

            Cat cat = new Cat();

            if (line[0] == "Siamese")
                cat = new Siamese {EarSize = int.Parse(line[2]), Name = line[1]};
            else if (line[0] == "Cymric")
                cat = new Cymric {FurSize = double.Parse(line[2]), Name = line[1]};
            else
                cat = new StreetExtraordinaire{DbsMeows = int.Parse(line[2]), Name = line[1]};
            cats.Add(cat);
        }
        string wantedName = Console.ReadLine();
        Cat theCat = cats.Find(x => x.Name.Equals(wantedName));
        Console.WriteLine(theCat.ToString());
    }
}