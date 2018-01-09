using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        
        HashSet<string> collection = new HashSet<string>();

        for (int i = 0; i < n; i++)
        {
            string name = Console.ReadLine();
            collection.Add(name);
        }
        Console.WriteLine(string.Join("\n", collection));
    }
}
