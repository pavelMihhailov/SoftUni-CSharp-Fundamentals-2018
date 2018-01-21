using System;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string[] names = Console.ReadLine().Split().Where(x => x.Length <= n).ToArray();
        Console.WriteLine(string.Join("\n", names));
    }
}
