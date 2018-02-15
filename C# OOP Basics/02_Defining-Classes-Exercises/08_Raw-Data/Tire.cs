using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

public class Tire
{
    private double pressure;
    private int age;

    public Tire(double pressure, int age)
    {
        this.pressure = pressure;
        this.age = age;
    }

    public int Age
    {
        get => this.age;
        set => this.age = value;
    }

    public double Pressure
    {
        get => this.pressure;
        set => this.pressure = value;
    }
}
