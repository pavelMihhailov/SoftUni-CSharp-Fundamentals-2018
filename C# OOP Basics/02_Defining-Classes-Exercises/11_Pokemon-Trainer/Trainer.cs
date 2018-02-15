using System;
using System.Collections.Generic;

public class Trainer
{
    private string name;

    private int badges;

    private List<Pokemon> pokemonCollection;

    public Trainer(string name)
    {
        this.name = name;
        this.badges = 0;
        this.pokemonCollection = new List<Pokemon>();
    }

    public string Name
    {
        get => this.name;
        set => this.name = value;
    }

    public int Badges
    {
        get => this.badges;
        set => this.badges = value;
    }

    public List<Pokemon> PokemonCollection
    {
        get => this.pokemonCollection;
        set => this.pokemonCollection = value;
    }
}
