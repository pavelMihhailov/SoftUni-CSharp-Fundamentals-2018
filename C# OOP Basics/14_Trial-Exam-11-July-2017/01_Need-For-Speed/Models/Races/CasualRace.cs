public class CasualRace : Race
{
    public CasualRace(int length, string route, int prizePool) : base(length, route, prizePool)
    {
    }
    

    public override int PerformancePoints(int id)
    {
        Car car = Participants[id];
        int performance = car.HorsePower / car.Acceleration + car.Suspension + car.Durability;
        return performance;
    }
}
