using System;
using System.Collections.Generic;

public class Car
{
    public string model;
    public int engineSpeed;
    public int enginePower;
    public int cargoWeight;
    public string cargoType;
    public KeyValuePair<double, int>[] tires;

    public Car(string input)
    {
        string[] parameters = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        string model = parameters[0];
        int engineSpeed = int.Parse(parameters[1]);
        int enginePower = int.Parse(parameters[2]);
        int cargoWeight = int.Parse(parameters[3]);
        string cargoType = parameters[4];
        double tire1Pressure = double.Parse(parameters[5]);
        int tire1age = int.Parse(parameters[6]);
        double tire2Pressure = double.Parse(parameters[7]);
        int tire2age = int.Parse(parameters[8]);
        double tire3Pressure = double.Parse(parameters[9]);
        int tire3age = int.Parse(parameters[10]);
        double tire4Pressure = double.Parse(parameters[11]);
        int tire4age = int.Parse(parameters[12]);

        this.model = model;
        this.engineSpeed = engineSpeed;
        this.enginePower = enginePower;
        this.cargoWeight = cargoWeight;
        this.cargoType = cargoType;
        this.tires = new [] { KeyValuePair.Create(tire1Pressure, tire1age), KeyValuePair.Create(tire2Pressure, tire2age), KeyValuePair.Create(tire3Pressure, tire3age), KeyValuePair.Create(tire4Pressure, tire4age) };
    }
}