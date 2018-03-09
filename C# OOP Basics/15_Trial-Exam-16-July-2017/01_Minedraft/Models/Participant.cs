public abstract class Participant
{
    protected Participant(string id)
    {
        Id = id;
    }

    public string Id { get; set; }
}