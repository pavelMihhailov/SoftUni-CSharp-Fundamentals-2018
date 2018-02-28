public class Citizen : Customer, IBirthdate, IId
{
    public Citizen(string name, int age, string id, string birthdate) : base(name, age)
    {
        Id = id;
        Birthdate = birthdate;
    }

    public string Birthdate { get; }

    public string Id { get; }

    public int Food { get; set; }
}
