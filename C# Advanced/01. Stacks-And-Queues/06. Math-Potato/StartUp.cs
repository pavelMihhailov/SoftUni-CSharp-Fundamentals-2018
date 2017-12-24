using System;
using System.Collections.Generic;

public class StartUp    
{
    public static void Main()
    {
        var children = Console.ReadLine().Split();
        int number = int.Parse(Console.ReadLine());

        var queueChildren = new Queue<string>(children);

        int counter = 1;

        while (queueChildren.Count > 1)
        {
            for (int i = 0; i < number - 1; i++)
            {
                queueChildren.Enqueue(queueChildren.Dequeue());
            }
            if (!isPrime(counter)) Console.WriteLine($"Removed {queueChildren.Dequeue()}");
            else Console.WriteLine($"Prime {queueChildren.Peek()}");
            counter++;
        }
        Console.WriteLine($"Last is {queueChildren.Dequeue()}");
    }

    public static bool isPrime(int number)
    {
        if (number == 1) return false;
        if (number == 2) return true;

        for (int i = 2; i <= Math.Ceiling(Math.Sqrt(number)); ++i)
        {
            if (number % i == 0) return false;
        }
        return true;
    }
}

