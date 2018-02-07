using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        List<string> jedis = new List<string>();

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            jedis.AddRange(input);
        }
        IEnumerable<string> orderedList = new List<string>();

        if (jedis.Any(x => x.StartsWith("y")))
        {
            orderedList = jedis.Where(x => !x.StartsWith("y")).OrderBy(x => x.StartsWith("p")).ThenBy(x => x.StartsWith("t") || x.StartsWith("s"))
                .ThenBy(x => x.StartsWith("k")).ThenBy(x => x.StartsWith("m"));
        }
        else
            orderedList = jedis.OrderBy(x => x.StartsWith("p")).ThenBy(x => x.StartsWith("k"))
                .ThenBy(x => x.StartsWith("m")).ThenBy(x => x.StartsWith("s") || x.StartsWith("t"));
        Console.WriteLine(string.Join(" ", orderedList));
    }
}
