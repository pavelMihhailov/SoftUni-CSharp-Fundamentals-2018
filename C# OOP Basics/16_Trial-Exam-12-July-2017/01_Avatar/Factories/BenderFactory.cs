using System.Collections.Generic;

public class BenderFactory
{
    public static Bender CreateBender(List<string> benderArgs)
    {
        Bender bender = null;

        string name = benderArgs[2];
        int power = int.Parse(benderArgs[3]);
        double secondaryParam = double.Parse(benderArgs[4]);

        switch (benderArgs[1])
        {
            case "Air":
                bender = new AirBender(name, power, secondaryParam);
                break;
            case "Water":
                bender = new WaterBender(name, power, secondaryParam);
                break;
            case "Fire":
                bender = new FireBender(name, power, secondaryParam);
                break;
            case "Earth":
                bender = new EarthBender(name, power, secondaryParam);
                break;
        }
        return bender;
    }
}
