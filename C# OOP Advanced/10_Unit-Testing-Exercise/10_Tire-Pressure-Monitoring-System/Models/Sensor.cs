using System;

public class Sensor : ISensor
{
    const double Offset = 16;
    readonly Random _randomPressureSampleSimulator = new Random();

    public double PopNextPressurePsiValue()
    {
        double pressureTelemetryValue = ReadPressureSample();

        return Offset + pressureTelemetryValue;
    }

    private double ReadPressureSample()
    {
        return 6 * _randomPressureSampleSimulator.NextDouble() * _randomPressureSampleSimulator.NextDouble();
    }
}
