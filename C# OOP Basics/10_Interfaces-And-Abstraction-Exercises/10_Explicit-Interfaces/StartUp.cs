using System;

public class StartUp
{
    public static void Main()
    {
        while (true)
        {
            string[] info = Console.ReadLine().Split();
            if (info[0] == "End") break;

            string name = info[0];
            string country = info[1];
            int age = int.Parse(info[2]);

            Citizen currCitizen = new Citizen(name, country, age);
            IPerson personCitizen = currCitizen;
            IResident residentCitizen = currCitizen;

            Console.WriteLine(personCitizen.GetName());
            Console.WriteLine(residentCitizen.GetName());
        }
    }
}
