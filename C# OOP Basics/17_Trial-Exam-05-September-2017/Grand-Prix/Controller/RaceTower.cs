using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RaceTower
{
    public RaceTower()
    {
        drivers = new Dictionary<string, Driver>();
        dnfDrivers = new Dictionary<Driver, string>();
        currentWeather = "Sunny";
        currLap = 0;
    }

    private int numberOfLaps;

    public int NumberOfLaps
    {
        get => numberOfLaps;
        set
        {
            if (value < 0) throw new ArgumentException($"There is no time! On lap {currLap}.");
            numberOfLaps = value;
        }
    }


    private int currLap;
    private int trackLength;
    private readonly Dictionary<string, Driver> drivers;
    private readonly Dictionary<Driver, string> dnfDrivers;
    private string currentWeather;
    public Driver winner;
    public bool endOfRace;

    public void SetTrackInfo(int lapsNumber, int trackLength)
    {
        NumberOfLaps = lapsNumber;
        this.trackLength = trackLength;
    }

    public void RegisterDriver(List<string> commandArgs)
    {
        try
        {
            Tyre tyre = TyreFactory.CreateTyre(commandArgs.Skip(4).ToList());
            Car car = CarFactory.CreateCar(commandArgs.Skip(2).Take(2).ToList(), tyre);
            Driver driver = DriverFactory.CreateDriver(commandArgs.Take(2).ToList(), car);
            drivers.Add(commandArgs[1], driver);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void DriverBoxes(List<string> commandArgs)
    {
        string reasonToBox = commandArgs[0];
        string driverName = commandArgs[1];

        drivers[driverName].TotalTime += 20;

        if (reasonToBox.Equals("Refuel"))
        {
            double fuelToFill = double.Parse(commandArgs[2]);

            drivers[driverName].Car.Refuel(fuelToFill);
        }
        else if (reasonToBox.Equals("ChangeTyres"))
        {
            var tyreArgs = commandArgs.Skip(2).ToList();
            var newTyre = TyreFactory.CreateTyre(tyreArgs);

            drivers[driverName].Car.ChangeTyre(newTyre);
        }
    }

    public string CompleteLaps(List<string> commandArgs)
    {
        int inputLaps = int.Parse(commandArgs[0]);
        StringBuilder result = new StringBuilder();

        try
        {
            NumberOfLaps -= inputLaps;
        }
        catch (ArgumentException e)
        {
            return e.Message;
        }

        for (int lap = 0; lap < inputLaps; lap++)
        {
            foreach (var driver in drivers.Values)
            {
                driver.TotalTime += 60 / (trackLength / driver.Speed);

                try
                {
                    driver.ReduceFuelAmount(trackLength);
                    driver.Car.Tyre.ReduceDegradation();
                }
                catch (ArgumentException e)
                {
                    dnfDrivers.Add(driver, e.Message);
                }

            }
            RemoveDnfDriversFromRace();
            currLap++;
            List<Driver> driversForOvertaken = drivers.Values.OrderByDescending(d => d.TotalTime).ToList();

            CheckForOvertaking(driversForOvertaken, result);
        }
        if (numberOfLaps == 0)
        {
            endOfRace = true;
            winner = drivers.Values.OrderBy(x => x.TotalTime).FirstOrDefault();
        }
        return result.ToString().TrimEnd();
    }

    private void RemoveDnfDriversFromRace()
    {
        foreach (var dnfDriver in dnfDrivers)
        {
            if (drivers.ContainsKey(dnfDriver.Key.Name))
            {
                drivers.Remove(dnfDriver.Key.Name);
            }
        }
    }

    public string GetLeaderboard()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Lap {currLap}/{currLap + numberOfLaps}");

        int position = 1;
        foreach (var driver in drivers.OrderBy(d => d.Value.TotalTime))
        {
            sb.AppendLine($"{position} {driver.Value.Name} {driver.Value.TotalTime:f3}");
            position++;
        }

        var dnfForPrint = dnfDrivers.Reverse();
        foreach (var driver in dnfForPrint)
        {
            sb.AppendLine($"{position} {driver.Key.Name} {driver.Value}");
            position++;
        }

        return sb.ToString().Trim();
    }

    public void ChangeWeather(List<string> commandArgs)
    {
        currentWeather = commandArgs[0];
    }

    public void CheckForOvertaking(List<Driver> driversForOvertake, StringBuilder result)
    {
        for (int i = 0; i < drivers.Count - 1; i++)
        {
            Driver firstDriver = driversForOvertake[i];
            Driver secondDriver = driversForOvertake[i + 1];
            double diff = Math.Abs(firstDriver.TotalTime - secondDriver.TotalTime);
            double overtakeInSecs = 2;

            bool crashed = false;
            CheckForSpecialCases(firstDriver, ref overtakeInSecs, ref crashed);

            if (diff <= overtakeInSecs)
            {
                if (crashed)
                {
                    dnfDrivers.Add(firstDriver, "Crashed");
                    RemoveDnfDriversFromRace();
                }
                else
                {
                    //print the overtake
                    firstDriver.TotalTime -= overtakeInSecs;
                    secondDriver.TotalTime += overtakeInSecs;
                    result.AppendLine($"{firstDriver.Name} has overtaken {secondDriver.Name} on lap {currLap}.");
                }
            }
        }
    }

    private void CheckForSpecialCases(Driver firstDriver, ref double overtakeInSecs, ref bool crashed)
    {
        if (firstDriver.GetType().Name.Equals("AggressiveDriver") &&
            firstDriver.Car.Tyre.GetType().Name.Equals("UltrasoftTyre"))
        {
            if (currentWeather.Equals("Foggy")) crashed = true;
            overtakeInSecs = 3;
        }
        else if (firstDriver.GetType().Name.Equals("EnduranceDriver") &&
                 firstDriver.Car.Tyre.GetType().Name.Equals("HardTyre"))
        {
            if (currentWeather.Equals("Rainy")) crashed = true;
            overtakeInSecs = 3;
        }
    }

    public void PrintWinner()
    {
        Console.WriteLine($"{winner.Name} wins the race for {winner.TotalTime:f3} seconds.");
    }
}
