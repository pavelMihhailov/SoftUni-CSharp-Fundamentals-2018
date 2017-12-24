using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var input = Console.ReadLine().Split().Reverse();
        Stack<string> numbersStack = new Stack<string>(input);

        while (numbersStack.Count > 1)
        {
            int firstNum = int.Parse(numbersStack.Pop());
            string operatorr = numbersStack.Pop();
            int secondNum = int.Parse(numbersStack.Pop());

            if (operatorr == "+") numbersStack.Push((firstNum + secondNum).ToString());
            else if (operatorr == "-") numbersStack.Push((firstNum - secondNum).ToString());
        }
        Console.WriteLine(numbersStack.Pop());
    }
}

