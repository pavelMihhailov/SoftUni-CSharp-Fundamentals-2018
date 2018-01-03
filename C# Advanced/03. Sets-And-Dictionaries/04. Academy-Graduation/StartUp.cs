using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        int students = int.Parse(Console.ReadLine());

        SortedDictionary<string, List<double>> studentsResults = new SortedDictionary<string, List<double>>();

        for (int i = 0; i < students; i++)
        {
            string name = Console.ReadLine();
            double[] grades = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();

            studentsResults.Add(name, new List<double>());
            studentsResults[name].AddRange(grades);
        }
        foreach (var studentsResult in studentsResults)
        {
            Console.WriteLine($"{studentsResult.Key} is graduated with {studentsResult.Value.Average()}");
        }
    }
}
