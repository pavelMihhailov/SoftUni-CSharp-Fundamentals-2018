using System;
using System.Linq;

class StartUp
{
    static void Main()
    {
        int[] numbers = Console.ReadLine().Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToArray();
        Console.WriteLine(numbers.Length + "\n" + numbers.Sum());
    }
}
