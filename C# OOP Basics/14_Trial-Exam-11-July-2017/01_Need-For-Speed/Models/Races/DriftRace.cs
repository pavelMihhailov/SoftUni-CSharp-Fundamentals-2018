public class DriftRace : Race
{
    public DriftRace(int length, string route, int prizePool) : base(length, route, prizePool)
    {
    }

    public override int PerformancePoints(int id)
    {
        Car car = Participants[id];
        return car.Suspension + car.Durability;
    }
}