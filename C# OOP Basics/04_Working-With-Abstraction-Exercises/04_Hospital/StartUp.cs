using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        Dictionary<string, List<string>> doctors = new Dictionary<string, List<string>>();
        Dictionary<string, List<List<string>>> departments = new Dictionary<string, List<List<string>>>();
        
        string command = Console.ReadLine();
        while (command != "Output")
        {
            string department, firstName, lastName, patient, fullName;
            ReadInput(command, out department, out firstName, out lastName, out patient, out fullName);

            if (!doctors.ContainsKey(firstName + lastName))
            {
                doctors[fullName] = new List<string>();
            }
            if (!departments.ContainsKey(department))
            {
                AddPatientToDepartment(departments, department);
            }

            bool hasFreeBed = departments[department].SelectMany(x => x).Count() < 60;
            if (hasFreeBed)
            {
                RegisterPatient(doctors, departments, department, patient, fullName);
            }

            command = Console.ReadLine();
        }
        command = Console.ReadLine();

        while (command != "End")
        {
            PrintWantedResult(doctors, departments, command);
            command = Console.ReadLine();
        }
    }

    private static void ReadInput(string command, out string department, out string firstName, out string lastName, out string patient, out string fullName)
    {
        string[] tokens = command.Split();
        department = tokens[0];
        firstName = tokens[1];
        lastName = tokens[2];
        patient = tokens[3];
        fullName = firstName + lastName;
    }

    private static void AddPatientToDepartment(Dictionary<string, List<List<string>>> departments, string department)
    {
        departments[department] = new List<List<string>>();
        for (int room = 0; room < 20; room++)
        {
            departments[department].Add(new List<string>());
        }
    }

    private static void RegisterPatient(Dictionary<string, List<string>> doctors, Dictionary<string, List<List<string>>> departments, string department, string patient, string fullName)
    {
        int roomIndex = 0;
        doctors[fullName].Add(patient);
        for (int room = 0; room < departments[department].Count; room++)
        {
            if (departments[department][room].Count < 3)
            {
                roomIndex = room;
                break;
            }
        }
        departments[department][roomIndex].Add(patient);
    }

    private static void PrintWantedResult(Dictionary<string, List<string>> doctors, Dictionary<string, List<List<string>>> departments, string command)
    {
        string[] args = command.Split();

        if (args.Length == 1)
        {
            Console.WriteLine(string.Join("\n", departments[args[0]].Where(x => x.Count > 0).SelectMany(x => x)));
        }
        else if (args.Length == 2 && int.TryParse(args[1], out int room))
        {
            Console.WriteLine(string.Join("\n", departments[args[0]][room - 1].OrderBy(x => x)));
        }
        else
        {
            Console.WriteLine(string.Join("\n", doctors[args[0] + args[1]].OrderBy(x => x)));
        }
    }
}
