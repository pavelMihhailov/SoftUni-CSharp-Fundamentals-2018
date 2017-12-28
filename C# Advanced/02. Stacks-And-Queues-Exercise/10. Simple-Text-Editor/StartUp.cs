using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        Stack<char> textStack = new Stack<char>();
        Stack<char> removedStringStack = new Stack<char>();
        Stack<string> commandStack = new Stack<string>();

        int operations = int.Parse(Console.ReadLine());

        for (int i = 0; i < operations; i++)
        {
            string input = Console.ReadLine();
            string[] splittedInput = input.Split();
            int command = int.Parse(splittedInput[0]);

            if (command == 1)
            {
                AppendText(textStack, commandStack, input, splittedInput);
            }
            else if (command == 2)
            {
                EraseElements(textStack, removedStringStack, commandStack, input, splittedInput);
            }
            else if (command == 3)
            {
                IndexPrint(textStack, splittedInput);
            }
            else if (command == 4)
            {
                UndoProcess(textStack, removedStringStack, commandStack);
            }
        }
    }

    private static void AppendText(Stack<char> textStack, Stack<string> commandStack, string input, string[] splittedInput)
    {
        string text = splittedInput[1];
        for (int j = 0; j < text.Length; j++)
        {
            textStack.Push(text[j]);
        }
        commandStack.Push(input);
    }

    private static void EraseElements(Stack<char> textStack, Stack<char> removedStringStack, Stack<string> commandStack, string input, string[] splittedInput)
    {
        int count = int.Parse(splittedInput[1]);
        for (int j = 0; j < count; j++)
        {
            removedStringStack.Push(textStack.Pop());
        }
        commandStack.Push(input);
    }

    private static void IndexPrint(Stack<char> textStack, string[] splittedInput)
    {
        int index = int.Parse(splittedInput[1]);
        char[] arr = textStack.ToArray().Reverse().ToArray();
        Console.WriteLine(arr[index - 1]);
    }

    private static void UndoProcess(Stack<char> textStack, Stack<char> removedStringStack, Stack<string> commandStack)
    {
        string[] lastCommand = commandStack.Pop().Split();
        if (lastCommand[0] == "1")
        {
            for (int j = 0; j < lastCommand[1].Length; j++)
            {
                textStack.Pop();
            }
        }
        else
        {
            for (int j = 0; j < int.Parse(lastCommand[1]); j++)
            {
                textStack.Push(removedStringStack.Pop());
            }
        }
    }
}
