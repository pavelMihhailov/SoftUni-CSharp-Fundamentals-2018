using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        Stack<ulong> fibonacciNumbers = new Stack<ulong>();
        fibonacciNumbers.Push(1);

        int targetFibonacci = int.Parse(Console.ReadLine());

        for (int i = 1; i <= targetFibonacci; i++)
        {
            if (i <= 2) fibonacciNumbers.Push(1);
            else CalcFibonacci(fibonacciNumbers);
        }
        Console.WriteLine(fibonacciNumbers.Pop());
    }

    private static void CalcFibonacci(Stack<ulong> fibonacciNumbers)
    {
        ulong oldA = fibonacciNumbers.Pop();
        ulong oldB = fibonacciNumbers.Pop();
        fibonacciNumbers.Push(oldB);
        fibonacciNumbers.Push(oldA);
        ulong newA = oldA + oldB;
        fibonacciNumbers.Push(newA);
    }
}
