using System;
using System.Collections.Generic;
using System.Text;

public class Car
{
    private string model;

    public string Model
    {
        get { return model; }
        set { model = value; }
    }

    private int speed;

    public int Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    public Car(string model, int speed)
    {
        this.model = model;
        this.speed = speed;
    }
}
