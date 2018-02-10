using System;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        int[] sequence = Console.ReadLine().Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToArray();

        int longestCnt = 0;

        for (int i = 1; i < sequence.Length; i++)
        {
            for (int j = 0; j < sequence.Length; j++)
            {
                int currLongestCnt = 1;

                int currIndex = j;
                int nextIndex = (currIndex + i) % sequence.Length;

                while (sequence[currIndex] < sequence[nextIndex])
                {
                    currLongestCnt++;

                    currIndex = nextIndex;
                    nextIndex = (currIndex + i) % sequence.Length;
                }
                if (currLongestCnt > longestCnt) longestCnt = currLongestCnt;
            }
        }
        Console.WriteLine(longestCnt);
    }
}
