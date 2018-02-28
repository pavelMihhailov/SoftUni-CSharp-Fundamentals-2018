public class Citizen : IId
{
    public string Id { get; set; }

    public string Name { get; set; }

    public int Age { get; set; }

    public Citizen(string name, int age, string id)
    {
        Name = name;
        Age = age;
        Id = id;
    }
}