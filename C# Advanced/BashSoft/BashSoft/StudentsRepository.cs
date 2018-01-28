using System;
using System.Collections.Generic;

class StudentsRepository
{
    public static bool isDataInitialized = false;

    private static Dictionary<string, Dictionary<string, List<int>>> studentsBycourse;

    public static void InitializeData()
    {
        if (!isDataInitialized)
        {
            OutputWriter.WriteMessageonNewLine("Reading data...");
            studentsBycourse = new Dictionary<string, Dictionary<string, List<int>>>();
            ReadData();
        }
        else
        {
            OutputWriter.DisplayException(ExceptionMessages.DataAlreadyInitializedException);
        }
    }

    private static void ReadData()
    {
        string input = Console.ReadLine();

        while (!string.IsNullOrEmpty(input))
        {
            string[] tokens = input.Split();
            string course = tokens[0];
            string student = tokens[1];
            int mark = int.Parse(tokens[2]);

            if (!studentsBycourse.ContainsKey(course))
            {
                studentsBycourse.Add(course, new Dictionary<string, List<int>>());
            }

            if (!studentsBycourse[course].ContainsKey(student))
            {
                studentsBycourse[course].Add(student, new List<int>());
            }

            studentsBycourse[course][student].Add(mark);
            input = Console.ReadLine();
        }

        isDataInitialized = true;
        OutputWriter.WriteMessageonNewLine("Data read!");
    }

    private static bool IsQueryForCoursePossible(string courseName)
    {
        if (isDataInitialized)
        {
            if (studentsBycourse.ContainsKey(courseName))
            {
                return true;
            }

            OutputWriter.DisplayException(ExceptionMessages.InexistingCourseInDataBase);
        }

        OutputWriter.DisplayException(ExceptionMessages.DataNotInitializedexceptionMessage);
        return false;
    }

    private static bool IsQueryForStudentPossible(string courseName, string studentUserName)
    {
        if (IsQueryForCoursePossible(courseName) && studentsBycourse[courseName].ContainsKey(studentUserName))
        {
            return true;
        }

        OutputWriter.DisplayException(ExceptionMessages.InexistingStudentInDataBase);

        return false;
    }

    public static void GetStudentScoresFromCourse(string courseName, string username)
    {
        if (IsQueryForStudentPossible(courseName, username))
        {
            OutputWriter.PrintStudent(new KeyValuePair<string, List<int>>(username, studentsBycourse[courseName][username]));
        }
    }

    public static void GetAllSudentsFromCourse(string courseName)
    {
        if (IsQueryForCoursePossible(courseName))
        {
            OutputWriter.WriteMessageonNewLine($"{courseName}:");
            foreach (var studentMarksEntry in studentsBycourse[courseName])
            {
                OutputWriter.PrintStudent(studentMarksEntry);
            }
        }
    }
}

