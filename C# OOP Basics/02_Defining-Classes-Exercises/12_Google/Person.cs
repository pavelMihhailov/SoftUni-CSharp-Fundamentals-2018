using System;
using System.Collections.Generic;

public class Person
{
    private string name;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    private Company company;

    public Company Company
    {
        get { return company; }
        set { company = value; }
    }

    private Car car;

    public Car Car
    {
        get { return car; }
        set { car = value; }
    }

    private List<Parent> parents = new List<Parent>();

    public List<Parent> Parents
    {
        get { return parents; }
        set { parents = value; }
    }

    private List<Children> childrens = new List<Children>();

    public List<Children> Childrens
    {
        get { return childrens; }
        set { childrens = value; }
    }

    private List<Pokemon> pokemons = new List<Pokemon>();

    public List<Pokemon> Pokemons
    {
        get { return pokemons; }
        set { pokemons = value; }
    }
}
