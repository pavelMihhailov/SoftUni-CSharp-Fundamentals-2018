using System;
using System.Collections.Generic;
using System.Text;

public class Family
{
    private List<Person> listOfPeople;

    public void AddMembers(Person member)
    {
        listOfPeople.Add(member);
    }

    public Person GetOldestMember()
    {
        int maxAge = 0;
        int personIndex = 0;
        for (int i = 0; i < listOfPeople.Count; i++)
        {
            if (listOfPeople[i].Age > maxAge)
            {
                maxAge = listOfPeople[i].Age;
                personIndex = i;
            }
        }
        return listOfPeople[personIndex];
    }

    public override string ToString()
    {
        return $"{GetOldestMember().Name} {GetOldestMember().Age}";
    }
}
