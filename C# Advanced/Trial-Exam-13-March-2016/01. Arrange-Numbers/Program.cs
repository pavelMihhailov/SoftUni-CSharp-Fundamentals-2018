using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string[] nums = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        var numbers = Console.ReadLine().Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

        Console.WriteLine(string.Join(", ", numbers.OrderBy(str => string.Join(string.Empty, str.Select(ch => nums[ch - '0'])))));
    }
}
