public class Citizen : IPerson, IBirthable, IIdentifiable
{
    private string name;

    private int age;

    private string birthdate;

    private string id;

    public string Name
    {
        get => this.name;
        private set => this.name = value;
    }

    public int Age
    {
        get => this.age;
        private set => this.age = value;
    }

    public string Birthdate
    {
        get => this.birthdate;
        private set => this.birthdate = value;
    }

    public string Id
    {
        get => this.id;
        private set => this.id = value;
    }

    public Citizen(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public Citizen(string name, int age, string id, string birthdate)
    {
        Name = name;
        Age = age;
        Id = id;
        Birthdate = birthdate;
    }
}
