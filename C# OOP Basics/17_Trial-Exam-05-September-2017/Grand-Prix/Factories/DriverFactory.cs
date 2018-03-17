using System.Collections.Generic;

public class DriverFactory
{
    public static Driver CreateDriver(List<string> args, Car car)
    {
        string type = args[0];
        string name = args[1];
        string tyreType = car.Tyre.GetType().Name;

        Driver driver = null;

        if (tyreType.Equals("Ultrasoft"))
        {
            if (type.Equals("Aggressive"))
                driver = new AggressiveDriver(name, car);
            else if (type.Equals("Endurance"))
                driver = new EnduranceDriver(name, car);
        }
        else
        {
            switch (type)
            {
                case "Aggressive":
                    driver = new AggressiveDriver(name, car);
                    break;
                case "Endurance":
                    driver = new EnduranceDriver(name, car);
                    break;
            }
        }
        return driver;
    }
}
