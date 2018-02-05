using System;
using System.Collections.Generic;
using System.Linq;

class StartUp
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split();
        Dictionary<string, List<string>> doctorPatients = new Dictionary<string, List<string>>();
        //department/room/patients
        Dictionary<string, Dictionary<int, List<string>>> depatmentInfo = new Dictionary<string, Dictionary<int, List<string>>>();

        while (input[0] != "Output")
        {
            string department = input[0];
            string doctor = input[1] + " " + input[2];
            string patient = input[3];

            AddInfoToHospital(doctorPatients, depatmentInfo, department, doctor, patient);

            input = Console.ReadLine().Split();
        }
        while (true)
        {
            input = Console.ReadLine().Split();
            if (input[0] == "End") break;
            Print(input, doctorPatients, depatmentInfo);
        }
    }

    private static void Print(string[] input, Dictionary<string, List<string>> doctorPatients, Dictionary<string, Dictionary<int, List<string>>> depatmentInfo)
    {
        //print department patients
        if (input.Length == 1)
        {
            foreach (var room in depatmentInfo[input[0]])
            {
                Console.WriteLine(string.Join("\n", room.Value));
            }
        }
        else
        {
            int room = -1;
            bool isDigit = int.TryParse(input.Last(), out room);
            //print department/room patients
            if (isDigit)
            {
                foreach (var patients in depatmentInfo[input[0]][room].OrderBy(x => x))
                {
                    Console.WriteLine(string.Join("\n", patients));
                }
            }
            //print doctor patients
            else
            {
                string doctor = input[0] + " " + input[1];
                foreach (var patients in doctorPatients[doctor].OrderBy(x => x))
                {
                    Console.WriteLine(string.Join("\n", patients));
                }
            }
        }
    }

    private static void AddInfoToHospital(Dictionary<string, List<string>> doctorPatients, Dictionary<string, Dictionary<int, List<string>>> depatmentInfo, string department, string doctor, string patient)
    {
        //add doctor and his patients
        if (!doctorPatients.ContainsKey(doctor))
        {
            doctorPatients.Add(doctor, new List<string>());
        }
        doctorPatients[doctor].Add(patient);
        //add department info
        if (!depatmentInfo.ContainsKey(department))
        {
            depatmentInfo.Add(department, new Dictionary<int, List<string>>());
            depatmentInfo[department].Add(1, new List<string>());
            depatmentInfo[department][1].Add(patient);
        }
        else
        {
            if (depatmentInfo[department].Count <= 20)
            {
                int roomForPatient = -1;
                for (int i = 1; i <= depatmentInfo[department].Keys.Count; i++)
                {
                    if (depatmentInfo[department][i].Count < 3)
                    {
                        roomForPatient = i;
                        break;
                    }
                }
                if (roomForPatient != -1)
                {
                    depatmentInfo[department][roomForPatient].Add(patient);
                }
                //add new room if neccesary
                else
                {
                    int cntRoomsInDepartment = depatmentInfo[department].Keys.Count + 1;
                    depatmentInfo[department].Add(cntRoomsInDepartment, new List<string>());
                    depatmentInfo[department][cntRoomsInDepartment].Add(patient);
                }
            }
        }
    }
}
