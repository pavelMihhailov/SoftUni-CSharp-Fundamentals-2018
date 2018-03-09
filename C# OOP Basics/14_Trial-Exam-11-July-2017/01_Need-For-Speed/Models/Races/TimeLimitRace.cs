using System.Linq;
using System.Text;

public class TimeLimitRace : Race
{
    public TimeLimitRace(int length, string route, int prizePool, int goldTime) : base(length, route, prizePool)
    {
        GoldTime = goldTime;
    }

    public int GoldTime { get; set; }

    public override int PerformancePoints(int id)
    {
        Car participant = this.Participants.First().Value;
        return Length * (participant.HorsePower / 100) * participant.Acceleration;
    }

    public int MoneyWon()
    {
        switch (GetTime())
        {
            case "Gold": return PrizePool;
            case "Silver": return PrizePool / 2;
            default: return PrizePool * 30 / 100;
        }
    }

    public string GetTime()
    {
        int totalTime = PerformancePoints(this.Participants.First().Key);

        if (totalTime <= GoldTime) return "Gold";
        if (totalTime <= GoldTime + 15) return "Silver";
        return "Bronze";
    }

    public override string ToString()
    {
        Car participant = this.Participants.First().Value;

        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{Route} - {Length}")
            .AppendLine($"{participant.Brand} {participant.Model} - {PerformancePoints(Participants.First().Key)} s.")
            .AppendLine($"{GetTime()} Time, ${MoneyWon()}.");

        return sb.ToString().Trim();
    }
}