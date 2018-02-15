using System;
using System.Collections.Generic;
using System.Linq;

public class Family
{
    private List<Person> listOfPeople;

    public Family()
    {
        this.listOfPeople = new List<Person>();
    }

    public void AddMembers(Person member)
    {
        listOfPeople.Add(member);
    }

    public Person GetOldestMember()
    {
        return listOfPeople.OrderByDescending(x => x.Age).FirstOrDefault();
    }
}
