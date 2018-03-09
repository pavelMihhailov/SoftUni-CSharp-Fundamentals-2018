public class DragRace : Race
{
    public DragRace(int length, string route, int prizePool) : base(length, route, prizePool)
    {
    }

    public override int PerformancePoints(int id)
    {
        Car car = Participants[id];
        return car.HorsePower / car.Acceleration;
    }
}
