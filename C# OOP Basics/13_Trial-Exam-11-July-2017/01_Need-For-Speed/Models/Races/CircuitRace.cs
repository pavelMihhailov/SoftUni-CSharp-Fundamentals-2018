using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CircuitRace : Race
{
    public CircuitRace(int length, string route, int prizePool, int laps) : base(length, route, prizePool)
    {
        Laps = laps;
    }

    public int Laps { get; set; }

    public override int PerformancePoints(int id)
    {
        Car car = Participants[id];
        int performance = car.HorsePower / car.Acceleration + car.Suspension + car.Durability;
        return performance;
    }

    public override Dictionary<int, Car> GetWinners()
    {
        for (int i = 0; i < Laps; i++)
        {
            foreach (var participant in Participants)
            {
                participant.Value.Durability -= Length * Length;
            }
        }

        var winners =
            Participants
                .OrderByDescending(x => this.PerformancePoints(x.Key))
                .Take(4)
                .ToDictionary(p => p.Key, p => p.Value);
        return winners;
    }

    public override int MoneyWon(int place)
    {
        if (place == 1) return PrizePool * 40 / 100;
        if (place == 2) return PrizePool * 30 / 100;
        if (place == 3) return PrizePool * 20 / 100;
        return PrizePool * 10 / 100;
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        result.AppendLine($"{Route} - {Length * Laps}");
        int place = 1;
        foreach (var winner in GetWinners())
        {
            result.AppendLine(
                $"{place}. {winner.Value.Brand} {winner.Value.Model} {PerformancePoints(winner.Key)}PP - ${MoneyWon(place)}");
            place++;
        }
        return result.ToString().Trim();
    }
}
