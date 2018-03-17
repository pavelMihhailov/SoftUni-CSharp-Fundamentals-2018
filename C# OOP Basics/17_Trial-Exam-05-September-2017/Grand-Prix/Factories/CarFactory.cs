using System.Collections.Generic;

public class CarFactory
{
    public static Car CreateCar(List<string> args, Tyre tyre)
    {
        int hp = int.Parse(args[0]);
        double fuelAmount = double.Parse(args[1]);

        Car car = new Car(hp, fuelAmount, tyre);

        return car;
    }
}
