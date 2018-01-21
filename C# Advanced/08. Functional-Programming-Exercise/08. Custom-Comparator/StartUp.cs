using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
        List<int> even = numbers.Where(num => num % 2 == 0).OrderBy(x => x).ToList();
        List<int> odd = numbers.Where(num => num % 2 != 0).OrderBy(x => x).ToList();
        List<int> result = new List<int>();
        result.AddRange(even);
        result.AddRange(odd);
        Console.WriteLine(string.Join(" ", result));
    }
}
