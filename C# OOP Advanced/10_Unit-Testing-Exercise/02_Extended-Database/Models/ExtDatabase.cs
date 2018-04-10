using System;
using System.Collections.Generic;
using System.Linq;

public class ExtDatabase
{
    private List<IPeople> listOfPeople;

    public ExtDatabase()
    {
        listOfPeople = new List<IPeople>();
    }

    public void AddPeople(IPeople people)
    {
        if (listOfPeople.Any(x => x.Username.Equals(people.Username)))
            throw new InvalidOperationException("Already has user with that username.");
        if (listOfPeople.Any(x => x.Id.Equals(people.Id)))
            throw new InvalidOperationException("Already has user with that id.");

        listOfPeople.Add(people);
    }

    public void RemovePeople(IPeople people)
    {
        listOfPeople.Remove(people);
    }

    public IPeople FindById(long id)
    {
        if (id < 0) throw new ArgumentOutOfRangeException();

        if (!listOfPeople.Any(x => x.Id.Equals(id)))
            throw new InvalidOperationException("No user with that id.");

        return listOfPeople.First(x => x.Id.Equals(id));
    }

    public IPeople FindByUsername(string username)
    {
        if (username == null) throw new ArgumentException($"Username cannot be null.");
        if (!listOfPeople.Any(x => x.Username.Equals(username)))
            throw new InvalidOperationException("No user with that username");

        return listOfPeople.First(x => x.Username.Equals(username));
    }

    public int GetCurrentDatabaseCount()
    {
        return listOfPeople.Count;
    }
}
