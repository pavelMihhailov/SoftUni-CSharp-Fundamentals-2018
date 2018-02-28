using System;

public abstract class MemberType : IBirthdate
{
    protected MemberType(string name, string birthdate)
    {
        Name = name;
        Birthdate = birthdate;
    }

    public string Name { get; set; }

    public string Birthdate { get; }

    public bool SameYear(string wantedYear)
    {
        return this.Birthdate.EndsWith(wantedYear);
    }
}
