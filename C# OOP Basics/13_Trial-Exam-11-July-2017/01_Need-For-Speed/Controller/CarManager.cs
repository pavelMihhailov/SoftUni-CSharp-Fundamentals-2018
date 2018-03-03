using System.Collections.Generic;
using System.Linq;

public class CarManager
{
    private Dictionary<int, Car> cars;
    private Dictionary<int, Race> races;
    private Garage garage;
    private List<int> closedRaces;

    public CarManager()
    {
        cars = new Dictionary<int, Car>();
        races = new Dictionary<int, Race>();
        garage = new Garage();
        closedRaces = new List<int>();
    }

    public void Register(int id, string type, string brand, string model, int productionYear, int horsePower, int acceleration, int suspension, int durability)
    {
        switch (type)
        {
            case "Performance":
                cars[id] = new PerformanceCar(brand, model, productionYear, horsePower, acceleration, suspension,
                    durability, new List<string>());
                break;
            case "Show":
                cars[id] = new ShowCar(brand, model, productionYear, horsePower, acceleration, suspension, durability);
                break;
        }
    }

    public string Check(int id)
    {
        return cars[id].ToString();
    }

    public void Open(int id, string type, int length, string route, int prizePool)
    {
        switch (type)
        {
            case "Casual":
                races[id] = new CasualRace(length, route, prizePool);
                break;
            case "Drag":
                races[id] = new DragRace(length, route, prizePool);
                break;
            case "Drift":
                races[id] = new DriftRace(length, route, prizePool);
                break;
        }
    }

    public void Open(int id, string type, int length, string route, int prizePool, int goldTimeOrLaps)
    {
        if (type.Equals("TimeLimit"))
        {
            races[id] = new TimeLimitRace(length, route, prizePool, goldTimeOrLaps);
        }
        else if (type.Equals("Circuit"))
        {
            races[id] = new CircuitRace(length, route, prizePool, goldTimeOrLaps);
        }
    }

    public void Participate(int carId, int raceId)
    {
        if (!garage.ParkedCars.Contains(carId) && !closedRaces.Contains(raceId))
        {
            Car car = cars[carId];
            if (races[raceId].GetType().Name.Equals("TimeLimit"))
            {
                if (races[raceId].Participants.Count == 0)
                {
                    races[raceId].Participants.Add(carId, car);
                }
            }
            else
                races[raceId].Participants.Add(carId, car);
        }
    }

    public string Start(int id)
    {
        if (races[id].Participants.Count == 0)
            return "Cannot start the race with zero participants.";

        if (!closedRaces.Contains(id))
        {
            var str = races[id].ToString();
            races.Remove(id);
            closedRaces.Add(id);
            return str;
        }
        return null;
    }

    public void Park(int id)
    {
        if (!races.Values.Any(x => x.Participants.ContainsKey(id)))
        {
            garage.AddCar(id);
        }
    }

    public void Unpark(int id)
    {
        garage.RemoveCar(id);
    }

    public void Tune(int tuneIndex, string addOn)
    {
        foreach (var carId in garage.ParkedCars)
        {
            cars[carId].Tune(tuneIndex, addOn);
        }

    }
}
