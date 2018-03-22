using System;

public class StartUp
{
    public static void Main()
    {
        var nameAddress = Console.ReadLine().Split();
        var name = nameAddress[0] + " " + nameAddress[1];
        var address = nameAddress[2];
        Tuple<string, string> tuple = new Tuple<string, string>(name, address);
        Console.WriteLine(tuple.ToString());

        var nameBeer = Console.ReadLine().Split();
        Tuple<string, int> tuple2 = new Tuple<string, int>(nameBeer[0], int.Parse(nameBeer[1]));
        Console.WriteLine(tuple2.ToString());

        var digits = Console.ReadLine().Split();
        Tuple<int, double> tuple3 = new Tuple<int, double>(int.Parse(digits[0]), double.Parse(digits[1]));
        Console.WriteLine(tuple3.ToString());
    }
}
