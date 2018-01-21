using System;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        Func<int[], int> smallestNum = GetMinNumber;
        int[] numbers = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToArray();
        Console.WriteLine(smallestNum(numbers));
    }

    public static int GetMinNumber(int[] numbers)
    {
        int min = Int32.MaxValue;
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] < min) min = numbers[i];
        }
        return min;
    }
}
