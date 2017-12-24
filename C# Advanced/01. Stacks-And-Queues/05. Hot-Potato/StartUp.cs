using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        string[] names = Console.ReadLine().Split();
        int number = int.Parse(Console.ReadLine());

        Queue<string> namesQueue = new Queue<string>(names);

        while (namesQueue.Count > 1)
        {
            for (int i = 1; i < number; i++)
            {
                namesQueue.Enqueue(namesQueue.Dequeue());
            }
            Console.WriteLine($"Removed {namesQueue.Dequeue()}");
        }
        Console.WriteLine($"Last is {namesQueue.Dequeue()}");
    }
}
