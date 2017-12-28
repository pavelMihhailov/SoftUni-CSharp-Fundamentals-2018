using System;
using System.Collections.Generic;

namespace _07.Balanced_Parentheses
{
    public class StartUp
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            Stack<char> openSkobas = new Stack<char>();
            bool balanced = true;

            if (input.Length % 2 != 0)
            {
                Console.WriteLine("NO");
            }

            else
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] == '{' || input[i] == '[' || input[i] == '(') openSkobas.Push(input[i]);

                    else if (input[i] == '}' || input[i] == ']' || input[i] == ')')
                    {
                        if (openSkobas.Count == 0)
                        {
                            balanced = false;
                            break;
                        }
                        else
                        {
                            if (input[i] == '}' && openSkobas.Peek() == '{') openSkobas.Pop();
                            else if (input[i] == ']' && openSkobas.Peek() == '[') openSkobas.Pop();
                            else if (input[i] == ')' && openSkobas.Peek() == '(') openSkobas.Pop();
                            else balanced = false;
                        }
                    }
                }
                Console.WriteLine(balanced ? "YES" : "NO");
            }
        }
    }
}
