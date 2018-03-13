using System.Collections.Generic;

public class MonumentFactory
{
    public static Monument CreateMonument(List<string> monumentArgs)
    {
        Monument monument = null;

        string name = monumentArgs[2];
        int affinity = int.Parse(monumentArgs[3]);

        switch (monumentArgs[1])
        {
            case "Air":
                monument = new AirMonument(name, affinity);
                break;
            case "Water":
                monument = new WaterMonument(name, affinity);
                break;
            case "Fire":
                monument = new FireMonument(name, affinity);
                break;
            case "Earth":
                monument = new EarthMonument(name, affinity);
                break;
        }
        return monument;
    }
}
