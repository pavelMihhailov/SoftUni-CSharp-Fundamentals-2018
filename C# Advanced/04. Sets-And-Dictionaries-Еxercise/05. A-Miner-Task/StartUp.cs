using System;
using System.Collections.Generic;
public class Program
{
    public static void Main()
    {
        Dictionary<string, long> recourses = new Dictionary<string, long>();

        while (true)
        {
            string recourse = Console.ReadLine();
            if (recourse == "stop") break;
            int quantity = int.Parse(Console.ReadLine());
            if (recourses.ContainsKey(recourse)) recourses[recourse] += quantity;
            else recourses.Add(recourse, quantity);
        }

        foreach (var recourse in recourses)
        {
            Console.WriteLine($"{recourse.Key} -> {recourse.Value}");
        }
    }
}
