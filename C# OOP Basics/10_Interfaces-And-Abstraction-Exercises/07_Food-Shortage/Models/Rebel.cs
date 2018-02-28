public class Rebel : Customer, IGroup
{
    public Rebel(string name, int age, string group) : base(name, age)
    {
        Group = group;
    }

    public string Group { get; }

    public int Food { get; set; }
}
