using System;

public class StartUp
{
    public static void Main()
    {
        var args1 = Console.ReadLine().Split();
        var name = args1[0] + " " + args1[1];
        var address = args1[2];
        var town = args1[3];
        Tuple<string, string, string> tuple = new Tuple<string, string, string>(name, address, town);
        Console.WriteLine(tuple.ToString());

        var args2 = Console.ReadLine().Split();
        bool drunk = args2[2].Equals("drunk");

        Tuple<string, int, bool> tuple2 = new Tuple<string, int, bool>(args2[0], int.Parse(args2[1]), drunk);
        Console.WriteLine(tuple2.ToString());

        var args3 = Console.ReadLine().Split();
        Tuple<string, double, string> tuple3 = new Tuple<string, double, string>(args3[0], double.Parse(args3[1]), args3[2]);
        Console.WriteLine(tuple3.ToString());
    }
}
