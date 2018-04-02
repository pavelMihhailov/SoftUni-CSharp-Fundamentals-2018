using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        string[] trafficLightsStr = Console.ReadLine().Split();
        int n = int.Parse(Console.ReadLine());
        var allLights = new List<TrafficLight>();

        foreach (var tr in trafficLightsStr)
        {
            var light = (Light)Enum.Parse(typeof(Light), tr);
            allLights.Add(new TrafficLight(light));
        }

        for (int i = 1; i <= n; i++)
        {
            foreach (var light in allLights)
            {
                light.SwitchState();
            }
            Console.WriteLine(string.Join(" ", allLights));
        }
    }
}
