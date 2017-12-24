using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        int decimalNum = int.Parse(Console.ReadLine());
        Stack<int> binaryNum = new Stack<int>();

        if (decimalNum == 0) binaryNum.Push(0);
        else
        {
            while (decimalNum > 0)
            {
                binaryNum.Push(decimalNum % 2);
                decimalNum /= 2;
            }
        }
        Console.WriteLine(string.Join("", binaryNum));
    }
}

