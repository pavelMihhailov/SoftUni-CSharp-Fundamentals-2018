using System;
using System.Collections.Generic;
using System.Linq;

public class Team
{
    private string name;

    public string Name
    {
        get { return name; }
        set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("A name should not be empty.");
            name = value;
        }
    }

    private List<Player> players;

    public List<Player> Players
    {
        get { return players; }
        set { players = value; }
    }

    public Team(string name)
    {
        Name = name;
        Players = new List<Player>();
    }

    public double Rating()
    {
        if (players.Count == 0) return 0;

        double result = players.Sum(x => x.Stats.Average());
        return (int)Math.Round(result / this.players.Count);

    }

    public override string ToString()
    {
        return $"{Name} - {Rating()}";
    }

    public void AddPlayer(Player player)
    {
        Players.Add(player);
    }

    public void RemovePlayer(string name)
    {
        Player player = players.FirstOrDefault(x => x.Name.Equals(name));
        if (player == null) throw new ArgumentException($"Player {name} is not in {this.name} team.");
        players.Remove(player);
    }

}
