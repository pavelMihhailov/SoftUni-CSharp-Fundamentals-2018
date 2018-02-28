public class Citizen : MemberType, IId
{
    public Citizen(string name, int age, string id, string birthdate) : base(name, birthdate)
    {
        Age = age;
        Id = id;
    }

    public string Id { get; set; }

    public int Age { get; set; }
}