using System;
using System.Collections.Generic;
using System.Text;

public class Team
{
    private string name;
    private List<Person> firstTeam;
    private List<Person> reserveTeam;

    public Team(string name)
    {
        this.name = name;
        this.firstTeam = new List<Person>();
        this.reserveTeam = new List<Person>();
    }

    public string Name
    {
        get => this.name;
        set => this.name = value;
    }

    public List<Person> FirstTeam
    {
        get => this.firstTeam;
    }

    public List<Person> ReserveTeam
    {
        get => this.reserveTeam;
    }

    public void AddPlayer(Person person)
    {
        if (person.Age < 40) firstTeam.Add(person);
        else reserveTeam.Add(person);
    }

    public override string ToString()
    {
        return $"First team has {firstTeam.Count} players.\nReserve team has {reserveTeam.Count} players.";
    }
}
