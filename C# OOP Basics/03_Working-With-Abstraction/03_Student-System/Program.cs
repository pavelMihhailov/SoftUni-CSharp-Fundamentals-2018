using System;

public class Program
{
    public static void Main()
    {
        StudentSystem studentSystem = new StudentSystem();
        while (true)
        {
            studentSystem.ParseCommand();
        }
    }
}
