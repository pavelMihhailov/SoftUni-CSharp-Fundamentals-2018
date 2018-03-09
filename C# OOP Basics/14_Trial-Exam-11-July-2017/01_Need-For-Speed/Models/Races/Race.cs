using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Race
{
    protected Race(int length, string route, int prizePool)
    {
        Length = length;
        Route = route;
        PrizePool = prizePool;
        Participants = new Dictionary<int, Car>();
    }

    public int Length { get; }
    public string Route { get; }
    public int PrizePool { get; }
    public Dictionary<int, Car> Participants { get; protected set; }

    public abstract int PerformancePoints(int id);

    public virtual Dictionary<int, Car> GetWinners()
    {
        var winners = 
            Participants
            .OrderByDescending(x => this.PerformancePoints(x.Key))
            .Take(3)
            .ToDictionary(p => p.Key, p => p.Value);
        return winners;
    }

    public virtual int MoneyWon(int place)
    {
        if (place == 1) return PrizePool / 2;
        if (place == 2) return PrizePool * 30 / 100;
        return PrizePool * 20 / 100;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{Route} - {Length}");
        int place = 1;
        foreach (var winner in GetWinners())
        {
            Car winCar = winner.Value;
            sb.AppendLine($"{place}. {winCar.Brand} {winCar.Model} {PerformancePoints(winner.Key)}PP - ${MoneyWon(place)}");
            place++;
        }
        return sb.ToString().Trim();
    }
}
