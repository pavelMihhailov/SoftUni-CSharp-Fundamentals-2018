public abstract class Customer : IBuyer
{
    protected Customer(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public string Name { get; }

    public int Age { get; }

    public int Food { get; set; }

    public void BuyFood(Customer customer)
    {
        if (customer is Citizen) Food += 10;
        else Food += 5;
    }
}
