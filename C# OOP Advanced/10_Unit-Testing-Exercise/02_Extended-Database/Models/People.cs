public class People : IPeople
{
    public People(long id, string username)
    {
        Id = id;
        Username = username;
    }

    public long Id { get; }

    public string Username { get; }
}