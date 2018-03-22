using System;

public class StartUp
{
    public static void Main()
    {
        var n = int.Parse(Console.ReadLine());

        //Problem 01.
        //for (int i = 0; i < n; i++)
        //{
        //    var box = new Box<string>(Console.ReadLine());
        //
        //    Console.WriteLine(box.ToString());
        //}

        //Problem 02.
        //for (int i = 0; i < n; i++)
        //{
        //    var box = new Box<int>(int.Parse(Console.ReadLine()));
        //
        //    Console.WriteLine(box.ToString());
        //}

        //Problem 03.
        //var box = new Box<string>();
        //
        //for (int i = 0; i < n; i++)
        //{
        //    box.Add(Console.ReadLine());
        //}
        //
        //int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
        //box.Swap(indexes[0], indexes[1]);
        //Console.WriteLine(box.ToString());

        //Problem 04.
        //var box = new Box<int>();
        //
        //for (int i = 0; i < n; i++)
        //{
        //    box.Add(int.Parse(Console.ReadLine()));
        //}
        //
        //int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
        //box.Swap(indexes[0], indexes[1]);
        //Console.WriteLine(box.ToString());

        //Problem 05.
        //var box = new Box<string>();
        //
        //for (int i = 0; i < n; i++)
        //{
        //    box.Add(Console.ReadLine());
        //}
        //var element = Console.ReadLine();
        //var equalElementsCnt = box.EqualsCount(element);
        //
        //Console.WriteLine(equalElementsCnt);

        //Problem 06.
        //var box = new Box<double>();
        //
        //for (int i = 0; i < n; i++)
        //{
        //    box.Add(double.Parse(Console.ReadLine()));
        //}
        //var element = double.Parse(Console.ReadLine());
        //var equalElementsCnt = box.EqualsCount(element);
        //
        //Console.WriteLine(equalElementsCnt);
    }
}
