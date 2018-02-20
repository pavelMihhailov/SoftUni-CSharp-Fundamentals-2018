using System;

public class Player
{
    private readonly string[] statNames = new string[] { "Endurance", "Sprint", "Dribble", "Passing", "Shooting" };

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

    private int[] stats;

    public int[] Stats
    {
        get => this.stats;
        private set
        {
            this.stats = new int[5];
            for (int i = 0; i < 5; i++)
            {
                if (value[i] < 0 || value[i] > 100)
                {
                    throw new ArgumentException($"{statNames[i]} should be between 0 and 100.");
                }
                this.stats[i] = value[i];
            }
        }
    }

    public Player(string name, int[] stats)
    {
        Name = name;
        Stats = stats;
    }
}